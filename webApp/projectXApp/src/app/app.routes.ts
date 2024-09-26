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
      .then(m => m.CompanyComponent), canActivate: [BaseGuard],
      children: [
        {
          path: 'employees',
          loadComponent: () => import('./company/employee/employee.component')
            .then(m => m.EmployeeComponent)
        },
        {
          path: 'about',
          loadComponent: () => import('./company/about/about/about.component')
            .then(m => m.AboutComponent)
        },
        {
          path: 'contact',
          loadComponent: () => import('./company/contact/contact/contact.component')
            .then(m => m.ContactComponent)
        }
      ]
  },
  { path: 'login', component: LoginComponent }
];