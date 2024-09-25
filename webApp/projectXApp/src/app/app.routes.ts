import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { BaseGuard } from './auth/base.guard';
import { AppComponent } from './app.component';
import { RootGuard } from './auth/root.guard';

export const routes: Routes = [
  { path: '', component: AppComponent, canActivate: [RootGuard] },
  {
    path: 'company/:companyUid',
    loadComponent: () => import('./company/company.component')
      .then(m => m.CompanyComponent), canActivate: [BaseGuard]
  },
  { path: 'login', component: LoginComponent },

  {
    path: 'company/:companyUid/employees',
    loadComponent: () => import('./company/employee/employee.component')
      .then(m => m.EmployeeComponent), canActivate: [BaseGuard]
  },

  {
    path: 'company/:companyUid/about',
    loadComponent: () => import('./company/about/about/about.component')
      .then(m => m.AboutComponent), canActivate: [BaseGuard]
  },
  {
    path: 'company/:companyUid/contact',
    loadComponent: () => import('./company/contact/contact/contact.component')
      .then(m => m.ContactComponent), canActivate: [BaseGuard]
  }
];