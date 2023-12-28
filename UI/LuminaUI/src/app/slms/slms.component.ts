import { Component } from '@angular/core';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { PAList } from '../shared/Models/PAList';
import { HttpClientModule } from '@angular/common/http';
import { PrmsService } from '../shared/Services/prms.service';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { SlmsService } from '../shared/Services/slms.service';
import { PMSService } from '../shared/Services/pms.service';
import { AddSaleComponent } from './add-sale/add-sale.component';
import {MatDialog, MatDialogModule} from '@angular/material/dialog';

@Component({
  selector: 'app-slms',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatTableModule,HttpClientModule,MatButtonModule,AddSaleComponent, MatDialogModule],
  templateUrl: './slms.component.html',
  styleUrl: './slms.component.css',
  providers:[PrmsService,SlmsService,PMSService]
})
export class SLMSComponent {
  constructor (private pmsService: PMSService,private router: Router, private slmsService:SlmsService,public dialog: MatDialog) {}
  products:PAList[] = [];
  displayedColumns: string[] = ['productID', 'Category', 'Color','Tag', 'Size','image'];
  dataSource = new MatTableDataSource<PAList>([]);

  ngOnInit() {
    this.getPAList()
    }
    openDialog(padID:string) {
      this.slmsService.setproductID(padID);
      const dialogRef = this.dialog.open(AddSaleComponent);
    }
    applyFilter(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
      this.dataSource.filter = filterValue.trim().toLowerCase();
    }
    getPAList() {
      this.pmsService.getPAList().subscribe((products: PAList[]) => {
        this.products = products;
        this.dataSource = new MatTableDataSource<PAList>(this.products);
      });
    }

  addSale(padID:string)
  {
    this.slmsService.setproductID(padID);
    this.router.navigate(['AddSale']);
  }
}
