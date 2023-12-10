import { Component } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import { ProductList } from '../../shared/Models/ProductList';

@Component({
  selector: 'app-productlist',
  standalone: true,
  imports: [MatCardModule, MatButtonModule,MatGridListModule],
  templateUrl: './productlist.component.html',
  styleUrl: './productlist.component.css'
})

export class ProductlistComponent {
  private product1: ProductList = new ProductList("121", "WL7824", "WALKAROO WOMEN SANDAL", "1", "299");
  private product2: ProductList = new ProductList("122", "WG5002", "WALKAROO MEN SOLID THONG SANDALS ART", "2", "299");
  private product3: ProductList = new ProductList("122", "WG5002", "WALKAROO MEN SOLID THONG SANDALS ART", "2", "299");
  private product4: ProductList = new ProductList("122", "WG5002", "WALKAROO MEN SOLID THONG SANDALS ART", "2", "299");
  public Products: ProductList[] = [];

  constructor() {
    // Add product1 and product2 to the Products array
    this.Products.push(this.product1);
    this.Products.push(this.product2);
    this.Products.push(this.product3);
    this.Products.push(this.product4);
  }
}
