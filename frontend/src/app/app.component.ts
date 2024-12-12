import { Component } from "@angular/core";
import { Router, RouterModule } from '@angular/router';
import { AuthService } from "./services/authService";
import { CommonModule } from "@angular/common";

@Component({
    standalone: true,
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    imports: [RouterModule, CommonModule]
})
export class AppComponent {
    constructor(private authService: AuthService, private router: Router){
        this.authService.loadUserIdFromToken();
    }
    

    isLoggedIn(): boolean {
        console.log("my token", localStorage.getItem('authToken'));
        return !!localStorage.getItem('authToken');
    }

    logout(): void {
        this.authService.logout();
        this.router.navigate(['/login']);
    }
}