import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

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

  constructor(private _fb: FormBuilder, private _httpClient: HttpClient) {
    this.formGroup = _fb.group({
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

      this._httpClient.post("https://localhost:7272/api/auth/login", request).subscribe(
        (response: any) => {
          console.log(response);
        },
        (error: any) => {
          console.log(error);
        },
        () => {
            console.log("finalize");
        }
      )
    }
  }
}
