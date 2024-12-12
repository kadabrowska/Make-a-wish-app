import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import {  ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  standalone: true,
  selector: 'app-homePage',
  templateUrl: './homePage.component.html',
  styleUrl: '../app.component.css',
  imports: [ReactiveFormsModule, CommonModule],
})
export class HomePageComponent {

  constructor(private apiService: ApiService, private router: Router) {}

  navigateToLogin() {
    this.router.navigate(['/login']);
  }

  navigateToRegister() {
    this.router.navigate(['/register']);
  }
}
