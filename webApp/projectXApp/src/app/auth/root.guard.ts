import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { BrowserService } from '../services/browser-storage.service';
import { TokenResponseDto } from '../shared/models/responses';

@Injectable({
  providedIn: 'root'
})
export class RootGuard implements CanActivate {

  constructor(
    private _router: Router,
    private _browserService: BrowserService) {}

  canActivate(): boolean {
    const token: TokenResponseDto | undefined = this._browserService.getStorageItem('token');

    if (!token) {

      this._router.navigate(['/login']);
      
      return false;
    }

    this._router.navigate(['/company', token.companyUid]);

    
    return true;
  }
}