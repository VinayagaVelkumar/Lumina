import { Component } from '@angular/core';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { Product } from '../shared/Models/Product';
import { HttpClientModule } from '@angular/common/http';
import { PrmsService } from '../shared/Services/prms.service';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { SlmsService } from '../shared/Services/slms.service';
@Component({
  selector: 'app-slms',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatTableModule,HttpClientModule,MatButtonModule],
  templateUrl: './slms.component.html',
  styleUrl: './slms.component.css',
  providers:[PrmsService,SlmsService]
})
export class SLMSComponent {
  constructor (private prmsService: PrmsService,private router: Router,private slmsService:SlmsService) {}
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

  getProducts() {
    this.prmsService.getProducts().subscribe((products: Product[]) => {
      this.products = products;
      this.dataSource = new MatTableDataSource<Product>(this.products);
    });
  }

  addProduct(productID:string)
  {
    this.slmsService.setproductID(productID);
    this.router.navigate(['AddSale']);
  }
}
