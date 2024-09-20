import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { BaseGuard } from './auth/base.guard';
import { AppComponent } from './app.component';
import { RootGuard } from './auth/root.guard';

export const routes: Routes = [
    { path: '', component: AppComponent, canActivate: [RootGuard] },
    { path: 'company/:companyUid', 
        loadComponent: () => import('./company/company.component')
            .then(m => m.CompanyComponent), canActivate: [BaseGuard] },
    { path: 'login', component: LoginComponent }
];