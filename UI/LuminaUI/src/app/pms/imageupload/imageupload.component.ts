import { Component } from '@angular/core';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { HttpClientModule } from '@angular/common/http';
import { PMSService } from '../../shared/Services/pms.service';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { PAList } from '../../shared/Models/PAList';

@Component({
  selector: 'app-imageupload',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatTableModule,HttpClientModule,MatButtonModule],
  templateUrl: './imageupload.component.html',
  styleUrl: './imageupload.component.css',
  providers:[PMSService]
})
export class ImageuploadComponent {
  constructor (private pmsService: PMSService,private router: Router) {}
  products:PAList[] = [];
  displayedColumns: string[] = ['productID', 'productName', 'brand', 'model','isActive'];
  dataSource = new MatTableDataSource<PAList>([]);

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit() {
  this.getPAImageList()
  }
  
  gotAddProduct()
{
  this.router.navigate(['Add Product'])
}

  getPAImageList() {
    this.pmsService.getPAImage().subscribe((products: PAList[]) => {
      this.products = products;
      this.dataSource = new MatTableDataSource<PAList>(this.products);
    });
  }

  uploadImage(productID:string)
  {
    // this.pmsService.setproductID(productID);
    // this.router.navigate(['AddPADetail']);
  }
}


