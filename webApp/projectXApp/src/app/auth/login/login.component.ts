import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  providers:[]
})
export class LoginComponent {
  
  public formGroup: FormGroup;

  constructor(
    private _fb: FormBuilder,
    private _authService: AuthService,
    private _router: Router) {
    this.formGroup = this._fb.group({
      "email": [],
      "password": []
    })
  }

  public onLogin(): void{
    if(this.formGroup.valid){
      let request = {
        email: this.formGroup.controls["email"].value,
        password: this.formGroup.controls["password"].value
      }

      // this._authService.login(request).subscribe(
      //   (response: any) => {
      //     console.log(response);
      //   },
      //   (error: any) => {
      //     console.log(error);
      //   },
      //   () => {
      //       console.log("finalize");
      //   }
      // )

      this._authService.login(request).subscribe({
        next: (res) => {
          console.log(res);
          localStorage.setItem('token', JSON.stringify(res.token));
          this._router.navigate(['/company']);
        },
        error: (e) => {console.log(e)},
        complete: () => console.log("Finalize - Complete")
      }
      )
    }
  }
}
