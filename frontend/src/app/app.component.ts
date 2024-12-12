import { Component } from "@angular/core";
import { RouterModule } from '@angular/router';
import { AuthService } from "./services/authService";

@Component({
    standalone: true,
    selector: 'app-root',
    template: `
    <body>
    <header>Make a wish app</header>
    <router-outlet></router-outlet>
    </body>`,
    styleUrls: ['./app.component.css'],
    imports: [RouterModule]
})
export class AppComponent {
    constructor(private authService: AuthService){
        this.authService.loadUserIdFromToken();
    }
}