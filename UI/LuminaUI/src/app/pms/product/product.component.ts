import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductList } from '../../shared/Models/ProductList';
import { PMSService } from '../../shared/Services/pms.service';

@Component({
  selector: 'app-product',
  standalone: false,
  templateUrl: './product.component.html',
  styleUrl: './product.component.css',
})
export class ProductComponent {
  receivedValue: string;
  product:ProductList = new ProductList('','','');
  
  slickConfig = {
    slidesToShow: 1,
    slidesToScroll: 1
  };
  constructor(private route: ActivatedRoute,private router: Router,private productService:PMSService) {
    this.receivedValue = ''
  }
  goToHome()
  {
    this.router.navigate(['Products' ]);
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.receivedValue = params['productID'];
      this.loadProducts();
    });
  
}
private loadProducts(): void {
  this.productService.getProductByID(this.receivedValue).subscribe(
    (product: ProductList ) => {
      this.product = product;
    },
    (error) => {
    }
  );
}
}
