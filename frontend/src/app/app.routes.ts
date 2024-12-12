import { Routes } from '@angular/router';
import { RegisterComponent } from './registration/register.component';
import { LoginComponent } from './login/login.component';
import { UsersComponent } from './users/users.component';
import { HomePageComponent } from './homePage/homePage.component';

export const routes: Routes = [
    {path:'', redirectTo: 'login', pathMatch: 'full'},
    {path:'home', component: HomePageComponent},
    {path:'register', component: RegisterComponent},
    {path:'login', component: LoginComponent},
    {path:'users', component: UsersComponent},

];

const routeConfig: Routes = [
    {
      path: '',
      component: HomePageComponent,
    },
    {
      path: 'register',
      component: RegisterComponent,
    },
    {
      path: 'login',
      component: LoginComponent,
    },
    {
        path: 'users',
        component: UsersComponent,
      },
  ];
  
  export default routeConfig;
