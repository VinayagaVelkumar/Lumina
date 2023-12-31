import { Component } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import { Product } from '../shared/Models/Product';
import { PrmsService } from '../shared/Services/prms.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-prms',
  standalone: false,
  templateUrl: './prms.component.html',
  styleUrl: './prms.component.css'
})
export class PRMSComponent {
  
  constructor (private prmsService: PrmsService,private router: Router) {}
  products:Product[] = [];
  displayedColumns: string[] = ['productID', 'productName', 'brand', 'model','isActive'];
  dataSource = new MatTableDataSource<Product>([]);

   applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit() {
  this.getProducts()
  }
  
  gotAddProduct()
{
  this.router.navigate(['AddProduct'])
}

  getProducts() {
    this.prmsService.getProducts().subscribe((products: Product[]) => {
      this.products = products;
      this.dataSource = new MatTableDataSource<Product>(this.products);
    });
  }

  addProduct(productID:string)
  {
    this.prmsService.setproductID(productID);
    this.router.navigate(['AddPADetail']);
  }
}
