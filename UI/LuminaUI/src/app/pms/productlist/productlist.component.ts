import { Component } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import { ProductList } from '../../shared/Models/ProductList';
import { Router } from '@angular/router';
import { PMSService } from '../../shared/Services/pms.service';
import { HttpClientModule } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { ProductFilter } from '../../shared/Models/ProductFilter';

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

  constructor(private router: Router,private productService: PMSService,private route: ActivatedRoute) {
  }
 Loading:boolean = true;
  ngOnInit(): void {
    const prFilter:ProductFilter = this.productService.getproductFilter();
      const categoryID = prFilter.categoryID;
      const modelID = prFilter.modelID;
      const sizeID = prFilter.sizeID;
      this.loadProducts(categoryID,modelID,sizeID);  
  }

  selectProduct(productID:string) {
    this.router.navigate(['/Product',productID ]);
  }
  private loadProducts(catID:number,modelID:number,sizeID:number): void {
    this.productService.getProducts(catID,modelID,sizeID).subscribe(
      (products: ProductList[]) => {
        this.Products = products;
        this.Loading = false;
      },
      (error) => {
        console.error('Error loading products:', error);
      }
    );
  }
}
