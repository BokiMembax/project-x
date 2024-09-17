import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { BaseGuard } from './auth/base.guard';

export const routes: Routes = [
    { path: 'company', 
        loadComponent: () => import('./company/company.component')
            .then(m => m.CompanyComponent), canActivate: [BaseGuard] }, // Protected route
    { path: 'login', component: LoginComponent }, // Unprotected login route
    { path: '', redirectTo: '/company', pathMatch: 'full' } // Default route
];
