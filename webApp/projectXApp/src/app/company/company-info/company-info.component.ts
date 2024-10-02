import { Component } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-company-info',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './company-info.component.html',
  styleUrl: './company-info.component.css'
})
export class CompanyInfoComponent {
  firstName = new FormControl();
  lastName = new FormControl();
  

  printCompany() {
    alert("First name: " + this.firstName.value + "\n" + "Last name: " + this.lastName.value);
  }
}
