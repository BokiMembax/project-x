import { Component } from '@angular/core';
import { CompanyNavbarComponent } from './navbar/company-navbar/company-navbar.component';
import { EmployeeComponent } from './employee/employee.component';

@Component({
  selector: 'app-company',
  standalone: true,
  imports: [CompanyNavbarComponent, EmployeeComponent],
  templateUrl: './company.component.html',
  styleUrl: './company.component.css'
})
export class CompanyComponent {

  
}
