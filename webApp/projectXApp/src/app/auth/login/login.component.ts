import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { BrowserService } from '../../services/browser-storage.service';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule, NgIf],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  providers:[]
})
export class LoginComponent implements OnInit {
  
  public formGroup: FormGroup;
  public showLoginForm: boolean = false;

  constructor(
    private _fb: FormBuilder,
    private _authService: AuthService,
    private _router: Router,
    private _browserService: BrowserService) {
    this.formGroup = this._fb.group({
      "email": [],
      "password": []
    })
  }

  ngOnInit(){
    this.isAlreadyLoggedIn();
  }

  public onLogin(): void{

    if(this.formGroup.valid){
      
      let request = {
        email: this.formGroup.controls["email"].value,
        password: this.formGroup.controls["password"].value
      }

      this._authService.login(request).subscribe({
        next: (res) => {

          this._browserService.setStorageItem('token', res.token);
          
          this._router.navigate(['/company']);
        },
        error: (e) => {console.log(e)},
        complete: () => console.log("Finalize - Complete")
      }
      )
    }
  }

  public isAlreadyLoggedIn(): void {
    const token = this._browserService.getStorageItem("token");

    this.showLoginForm = token ? false : true;

    if(token){
      this._router.navigate(['/company']);
    }
  }
}
