import { Component } from '@angular/core';
import { ApiService } from '../services/api.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthService } from '../services/authService';

@Component({
  standalone: true,
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: '../app.component.css',
  imports: [ReactiveFormsModule, CommonModule],
})
export class LoginComponent {
  title = 'Login';
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private apiService: ApiService, private router: Router, private authService: AuthService) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

loginUser(): void {
  const userData = this.loginForm.value;
  this.apiService.login(userData).subscribe({
    next: (response: any) => {
      this.authService.setToken(response.token);
      console.log("token set", response.token)

      const userId = this.authService.getCurrentUserId();
      console.log('Logged user: ID:', userId);
      this.router.navigate(['/users']);
    },
    error: (error) => {
      console.error("Login failed", error);
    },
  });
}
}
