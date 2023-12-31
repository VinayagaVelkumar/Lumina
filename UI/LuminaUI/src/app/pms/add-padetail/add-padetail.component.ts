import { Component } from '@angular/core';
import { PMSService } from '../../shared/Services/pms.service';
import { Category } from '../../shared/Models/Category';
import { Size } from '../../shared/Models/Size';
import { Router } from '@angular/router';
import { PrmsService } from '../../shared/Services/prms.service';
import { Color } from '../../shared/Models/Color';
import { Tag } from '../../shared/Models/Tag';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonService } from '../../shared/Services/common.service';

@Component({
  selector: 'app-add-padetail',
  standalone: false,
  templateUrl: './add-padetail.component.html',
  styleUrl: './add-padetail.component.css'
})
export class AddPADetailComponent {
  categories: Category[] = [];
  sizes: Size[] = [];
  colors: Color[] = [];
  tags: Tag[] =[];
  selectedCategoryId:string = '';
  selectedSizes: number[] = [];
  selectedColorId: string ='';
  mrp:string ='';
  count:string ='';
  purPrice:string ='';
  discount:string ='';
  tagID:string ='';

  productID: string = '';
  constructor(private pmsService: PMSService ,private commonService:CommonService ,private router: Router, private prmsService: PrmsService,private snackBar:MatSnackBar) {}
  
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
    this.selectedCategoryId = categoryId.toString();
    this.getSizes(categoryId);
  }


  onColorSelected(colorID: number) {
    this.selectedColorId = colorID.toString();
  }

  onTagSelected(tagID: number) {
    this.tagID = tagID.toString();
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
    CategoryId: parseInt(this.selectedCategoryId),
    SizeIDs: this.selectedSizes,
    ColorId: parseInt(this.selectedColorId),
    MRP: this .pmsService.removeLeadingZeros(parseInt(this.mrp)),
    Count: this .pmsService.removeLeadingZeros(parseInt(this.count)),
    PurchasePrice: this .pmsService.removeLeadingZeros(parseInt(this.purPrice)),
    DiscountCode: this .pmsService.removeLeadingZeros(parseInt(this.discount)),
    TagID: parseInt(this.tagID)
  };

  this.prmsService.addPurchase(data).subscribe(
    (response) => {
      this.openSuccessMessage('Successfully Saved !')
      this.commonService.setImagesCount(0);
      this.router.navigate(['Purchase'])
    },
    (error) => {
    }
  );
}
}
