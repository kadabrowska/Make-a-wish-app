import { HttpClient, provideHttpClient, withFetch} from '@angular/common/http'
import { RegisterComponent } from './registration/register.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { routes } from './app.routes';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UsersComponent } from './users/users.component';
import { AuthService } from './services/authService';

@NgModule({
    declarations: [
        RegisterComponent,
        LoginComponent,
        UsersComponent,
        HttpClient
    ],
    imports: [
        BrowserModule, 
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        RouterModule.forRoot(routes),
        HttpClient,
    ],
    providers: [
        provideHttpClient(),
        [AuthService]
    ],
    bootstrap: [RegisterComponent]
})
export class AppModule {}