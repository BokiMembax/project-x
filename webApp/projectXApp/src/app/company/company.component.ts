import { Component } from '@angular/core';
import { CompanyNavbarComponent } from './navbar/company-navbar/company-navbar.component';

@Component({
  selector: 'app-company',
  standalone: true,
  imports: [CompanyNavbarComponent],
  templateUrl: './company.component.html',
  styleUrl: './company.component.css'
})
export class CompanyComponent {

  
}
