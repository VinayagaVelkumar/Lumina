import { Component } from '@angular/core';
import {MatTableDataSource,   MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { HttpClientModule } from '@angular/common/http';
import { PMSService } from '../../shared/Services/pms.service';
import { Router } from '@angular/router';
import { PAList } from '../../shared/Models/PAList';
import { CommonService } from '../../shared/Services/common.service';

@Component({
  selector: 'app-imageupload',
  standalone: false,
  templateUrl: './imageupload.component.html',
  styleUrl: './imageupload.component.css'
})
export class ImageuploadComponent {
  constructor (private pmsService: PMSService,private commonService:CommonService,private router: Router) {}
  products:PAList[] = [];
  displayedColumns: string[] = ['productID', 'Category', 'Color', 'image'];
  dataSource = new MatTableDataSource<PAList>([]);
  selectedProductID: string ='';
  selectedCategoryID: number = 0;
  selectedColorID: number = 0

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit() {
  this.getPAImageList()
  }

  getPAImageList() {
    this.pmsService.getPAImage().subscribe((products: PAList[]) => {
      this.products = products;
      this.dataSource = new MatTableDataSource<PAList>(this.products);
    });
  }

  onUploadClick(productID:string, categoryID:number, colorID:number)
  {
    this.selectedCategoryID = categoryID;
    this.selectedColorID = colorID;
    this.selectedProductID = productID;
  }

  onFileSelected(event: any): void {
    const file = event.target.files[0];

    if (file) {
            this.pmsService.UploadImage(this.selectedProductID,this.selectedCategoryID,this.selectedColorID,file).subscribe((result:boolean)=>
            {
              if(result == true)
              {
                this.commonService.setImagesCount(0); //initializing call to controller
                this.getPAImageList();
              }
            }
            );
    }
}
}


