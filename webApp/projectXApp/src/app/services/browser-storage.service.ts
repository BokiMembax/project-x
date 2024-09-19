import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BrowserService {

  constructor() {}

    public getStorageItem<T>(key: string): T | undefined{

        let localStorageItem = localStorage.getItem(key);

        if(!localStorageItem){
            return undefined;
        }

        let storageItem: T = JSON.parse(localStorageItem);
        
        return storageItem;
    }

    public setStorageItem<T>(key: string, value: T): void {
        localStorage.setItem(key, JSON.stringify(value));
    }

    public removeStorage(key: string): void {
        localStorage.removeItem(key);
    }
}