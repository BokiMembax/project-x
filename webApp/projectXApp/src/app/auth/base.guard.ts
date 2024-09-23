import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { BrowserService } from '../services/browser-storage.service';

@Injectable({
  providedIn: 'root'
})
export class BaseGuard implements CanActivate {

  constructor(
    private _router: Router,
    private _browserService: BrowserService) {}

  canActivate(): boolean {
    const isAuthenticated = this._browserService.getStorageItem('token');

    if (!isAuthenticated) {

      this._router.navigate(['/login']);
      
      return false;
    }
    
    return true;
  }
}