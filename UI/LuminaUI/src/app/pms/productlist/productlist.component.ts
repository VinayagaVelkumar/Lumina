import { Component } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import { ProductList } from '../../shared/Models/ProductList';
import { Router } from '@angular/router';
import { PMSService } from '../../shared/Services/pms.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-productlist',
  standalone: true,
  imports: [MatCardModule, MatButtonModule,MatGridListModule,HttpClientModule],
  templateUrl: './productlist.component.html',
  styleUrl: './productlist.component.css',
  providers:[PMSService]
})

export class ProductlistComponent {

  public Products: ProductList[] = [];

  constructor(private router: Router,private productService: PMSService) {
  }
 Loading:boolean = true;
  ngOnInit(): void {
    this.loadProducts();
  }

  selectProduct(productID:string) {
    this.router.navigate(['/Product',productID ]);
  }
  private loadProducts(): void {
    this.productService.getProducts().subscribe(
      (products: ProductList[]) => {
        debugger
        this.Products = products;
        this.Loading = false;
      },
      (error) => {
        console.error('Error loading products:', error);
      }
    );
  }
}
