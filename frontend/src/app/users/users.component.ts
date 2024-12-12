import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthService } from '../services/authService';
import { ChangeDetectorRef } from '@angular/core';


@Component({
  standalone: true,
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrl: '../app.component.css',
  imports: [ReactiveFormsModule, CommonModule],
})
export class UsersComponent implements OnInit {
    users: any[] = [];
    currentUserId: number | null = null;

  constructor(
    private apiService: ApiService, 
    private router: Router, 
    private authService: AuthService,
    private cdr: ChangeDetectorRef) {}

    ngOnInit(): void {
        this.currentUserId = this.authService.getCurrentUserId();

        this.apiService.getUsers().subscribe({
            next: (data) => {
                console.log(data);
                this.users = data;
                console.log('data for users:', data)
            },
            error: (error) => {
                console.error('Failed to fetch list of users', error);
            },
        });
    }

    assign(receiverId: number): void {
        const giverId = this.authService.getCurrentUserId();
        if (giverId === null) {
            alert('You must be logged in to assign a user');
            return;
        }
        console.log(`giver id ${giverId} receiver id ${receiverId}`);
        if (giverId === receiverId) {
            alert('You cannot assign yourself');
            return;
        }

        this.apiService.assign(giverId, receiverId)
        .subscribe({
            next: () => { alert('You got an assignment'),
            this.apiService.getUsers().subscribe({
                next: (data) => {
                    console.log("updated users", data)
                    this.users = data;
                    this.cdr.detectChanges();
                },
                error: (err) => console.error('Failed to refresh users', err),
            });
        },
            error: () => console.error('Error')
        });
    }
}
