import { Component } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import { Router } from '@angular/router';
import { SlmsService } from '../shared/Services/slms.service';
import { PMSService } from '../shared/Services/pms.service';
import { AddSaleComponent } from './add-sale/add-sale.component';
import {MatDialog} from '@angular/material/dialog';
import { SalePAList } from '../shared/Models/SalePAList';

@Component({
  selector: 'app-slms',
  standalone: false,
  templateUrl: './slms.component.html',
  styleUrl: './slms.component.css'
})
export class SLMSComponent {
  constructor (private pmsService: PMSService,private router: Router, private slmsService:SlmsService,public dialog: MatDialog) {}
  products:SalePAList[] = [];
  displayedColumns: string[] = ['productID', 'Category', 'Color','Tag', 'Size','image'];
  dataSource = new MatTableDataSource<SalePAList>([]);

  filterOptions: { category: string[], color: string[], size: string[] } = {
    category: [],
    color: [],
    size: []
  };
  categoryFilterValue:string ='';
  sizeFilterValue:string = '';
  colorFilterValue:string =  '';

  ngOnInit() {
  this.slmsService.setSalePAList();
  this.slmsService.salePAList$.subscribe((result) => {
    this.products = result;
    this.dataSource = new MatTableDataSource<SalePAList>(this.products);
    this.filterOptions.category = Array.from(new Set(this.products.map(item => item.category)));
    this.filterOptions.color = Array.from(new Set(this.products.map(item => item.color)));
    this.filterOptions.size = Array.from(new Set(this.products.map(item => item.size.toString())));
  });
    }

    openDialog(padID:string, productID:string,MRP:string,Discount:string,Count:string) {
      this.slmsService.setproductID(padID,productID,MRP,Discount,Count);
      const dialogRef = this.dialog.open(AddSaleComponent);
    }

    applyFilter(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
      this.dataSource.filter = filterValue.trim().toLowerCase();
    }
}
