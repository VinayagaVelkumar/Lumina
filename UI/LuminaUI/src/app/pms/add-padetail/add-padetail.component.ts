import { Component } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { PMSService } from '../../shared/Services/pms.service';
import { Category } from '../../shared/Models/Category';
import { Size } from '../../shared/Models/Size';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { PrmsService } from '../../shared/Services/prms.service';
import { Color } from '../../shared/Models/Color';
import { Tag } from '../../shared/Models/Tag';
import { MatSnackBar,MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-padetail',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, MatInputModule, FormsModule,HttpClientModule,MatButtonModule,MatSnackBarModule],
  templateUrl: './add-padetail.component.html',
  styleUrl: './add-padetail.component.css',
  providers: [PMSService,PrmsService]
})
export class AddPADetailComponent {
  categories: Category[] = [];
  sizes: Size[] = [];
  colors: Color[] = [];
  tags: Tag[] =[];
  selectedCategoryId:number = 0;
  selectedSizes: number[] = [];
  selectedColorId: Number =0;
  mrp:number =0;
  count:number =0;
  purPrice:number =0;
  discount:number =0;
  tagID:number =0;

  productID: string = '';
  constructor(private pmsService: PMSService  ,private router: Router, private prmsService: PrmsService,private snackBar:MatSnackBar) {}
  
  ngOnInit() {
    this.getCategories();
    this.getColors();
    this.getTags();
    this.productID = this.prmsService.getproductID();
  }

  getCategories() {
    this.pmsService.getCategories().subscribe((categories: Category[]) => {
      this.categories = categories;
    });
  }

  getColors() {
    this.pmsService.getColors().subscribe((colors: Color[]) => {
      this.colors = colors;
    });
  }

  getTags() {
    this.pmsService.getTags().subscribe((tags: Tag[]) => {
      this.tags = tags;
    });
  }

  onCategorySelected(categoryId: number) {
    this.selectedCategoryId = categoryId;
    this.getSizes(categoryId);
  }


  onColorSelected(colorID: number) {
    this.selectedColorId = colorID;
  }

  onTagSelected(tagID: number) {
    this.tagID = tagID;
  }

  getSizes(categoryId: number) {
    this.pmsService.getSizes(categoryId).subscribe((sizes: Size[]) => {
      this.sizes = sizes;
    });
}

openSuccessMessage(message: string): void {
  this.snackBar.open(message, 'Close', {
    duration: 5000,
    verticalPosition: 'top',
    panelClass: ['success-snackbar'],
  });
}


trackBySizeID(index: number, size: any): number {
  return size.sizeID;
}

addPurchase()
{
  const data = {
    ProductID: this.productID,
    CategoryId: this.selectedCategoryId,
    SizeIDs: this.selectedSizes,
    ColorId: this.selectedColorId,
    MRP: this .pmsService.removeLeadingZeros(this.mrp),
    Count: this .pmsService.removeLeadingZeros(this.count),
    PurchasePrice: this .pmsService.removeLeadingZeros(this.purPrice),
    DiscountCode: this .pmsService.removeLeadingZeros(this.discount),
    TagID: this.tagID
  };

  this.prmsService.addPurchase(data).subscribe(
    (response) => {
      this.openSuccessMessage('Successfully Saved !')
      this.router.navigate(['Purchase'])
    },
    (error) => {
      console.error('Error sending data:', error);
    }
  );
}
}
