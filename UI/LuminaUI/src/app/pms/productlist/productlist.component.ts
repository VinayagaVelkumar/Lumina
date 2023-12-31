import { Component } from '@angular/core';
import { ProductList } from '../../shared/Models/ProductList';
import { Router } from '@angular/router';
import { PMSService } from '../../shared/Services/pms.service';
import { ActivatedRoute } from '@angular/router';
import { ProductFilter } from '../../shared/Models/ProductFilter';

@Component({
  selector: 'app-productlist',
  standalone: false,
  templateUrl: './productlist.component.html',
  styleUrl: './productlist.component.css',
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

  private loadProducts(catID:number,modelID:number,sizeID:number): void {
    this.productService.getProducts(catID,modelID,sizeID).subscribe(
      (products: ProductList[]) => {
        this.Products = products;
        this.Loading = false;
      },
      (error) => {
      }
    );
  }
}
