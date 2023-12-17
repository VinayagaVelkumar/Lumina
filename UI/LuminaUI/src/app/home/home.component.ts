import { Component } from '@angular/core';
import { ProductlistComponent } from '../pms/productlist/productlist.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ProductlistComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
