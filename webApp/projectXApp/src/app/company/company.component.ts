import { Component } from '@angular/core';
import { CompanyNavbarComponent } from './company-navbar/company-navbar.component';
import { EmployeeComponent } from './employee/employee.component';
import { RouterOutlet } from '@angular/router';
import { VehicleComponent } from './vehicle/vehicle.component';
import { CompanyInfoComponent } from './company-info/company-info.component';

@Component({
  selector: 'app-company',
  standalone: true,
  imports: [CompanyNavbarComponent, CompanyInfoComponent, EmployeeComponent, VehicleComponent, RouterOutlet],
  templateUrl: './company.component.html',
  styleUrl: './company.component.css'
})
export class CompanyComponent {

  
}
