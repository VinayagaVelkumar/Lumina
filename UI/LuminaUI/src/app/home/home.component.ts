import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { ProductlistComponent } from '../pms/productlist/productlist.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NavbarComponent,ProductlistComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
