import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-company-navbar',
  standalone: true,
  imports: [RouterLink, RouterOutlet],
  templateUrl: './company-navbar.component.html',
  styleUrl: './company-navbar.component.css'
})
export class CompanyNavbarComponent {
  public companyUid: string = ''
}
