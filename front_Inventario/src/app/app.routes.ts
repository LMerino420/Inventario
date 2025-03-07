import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegistComponent } from './auth/regist/regist.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'regist', component: RegistComponent },
];
