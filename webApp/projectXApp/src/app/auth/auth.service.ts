import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7272/api';

  constructor(private _httpClient: HttpClient) {}

  public getData(): Observable<any> {
    return this._httpClient.get<any>(this.apiUrl).pipe(
      tap(response => {
        localStorage.setItem('data', JSON.stringify(response));
      })
    );
  }

  public login(request: any): Observable<any> {
    return this._httpClient.post("https://localhost:7272/api/auth/login", request);
  }
}