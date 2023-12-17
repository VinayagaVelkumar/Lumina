import { Component } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import { ProductList } from '../../shared/Models/ProductList';
import { Router } from '@angular/router';

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
  private product5: ProductList = new ProductList("122", "WG5002", "WALKAROO MEN SOLID THONG SANDALS ART", "2", "299");
  private product6: ProductList = new ProductList("122", "WG5002", "WALKAROO MEN SOLID THONG SANDALS ART", "2", "299");
  private product7: ProductList = new ProductList("122", "WG5002", "WALKAROO MEN SOLID THONG SANDALS ART", "2", "299");
  private product8: ProductList = new ProductList("122", "WG5002", "WALKAROO MEN SOLID THONG SANDALS ART", "2", "299");
  private product9: ProductList = new ProductList("122", "WG5002", "WALKAROO MEN SOLID THONG SANDALS ART", "2", "299");
  private product10: ProductList = new ProductList("122", "WG5002", "WALKAROO MEN SOLID THONG SANDALS ART", "2", "299");
  public Products: ProductList[] = [];

  constructor(private router: Router) {
    // Add product1 and product2 to the Products array
    this.Products.push(this.product1);
    this.Products.push(this.product2);
    this.Products.push(this.product3);
    this.Products.push(this.product4);
    this.Products.push(this.product5);
    this.Products.push(this.product6);
    this.Products.push(this.product7);
    this.Products.push(this.product8);
    this.Products.push(this.product9);
    this.Products.push(this.product10);
  }
  selectProduct(productID:string) {
    this.router.navigate(['/Product',productID ]);
  }
}
