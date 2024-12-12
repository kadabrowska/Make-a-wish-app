import { Component } from '@angular/core';
import { ApiService } from '../services/api.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: '../app.component.css',
  imports: [ReactiveFormsModule, CommonModule],
})
export class RegisterComponent {
  title = 'Registration';
  registerForm: FormGroup;

  constructor(private fb: FormBuilder, private apiService: ApiService, private router: Router) {
    this.registerForm = this.fb.group({
      name: ['', Validators.required],
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

registerUser() {
  if (this.registerForm.valid){
    this.apiService.register(this.registerForm.value).subscribe(
      () => {
        alert("User registered successfully");
        this.router.navigate(['/login']);
      },
    (error: any) => {
      console.error("Registration failed", error);
    }
  );
} else {
  console.log("Form is invalid");
}
}
}
