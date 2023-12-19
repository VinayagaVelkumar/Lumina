import { Component } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { PMSService } from '../../shared/Services/pms.service';
import { Category } from '../../shared/Models/Category';
import { Model } from '../../shared/Models/Model';
import { Size } from '../../shared/Models/Size';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { PrmsService } from '../../shared/Services/prms.service';
import { Color } from '../../shared/Models/Color';

@Component({
  selector: 'app-add-padetail',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, MatInputModule, FormsModule,HttpClientModule,MatButtonModule],
  templateUrl: './add-padetail.component.html',
  styleUrl: './add-padetail.component.css',
  providers: [PMSService,PrmsService]
})
export class AddPADetailComponent {
  categories: Category[] = [];
  sizes: Size[] = [];
  colors: Color[] = [];
  selectedCategoryId:number = 0;
  selectedSizeId: Number =0;
  selectedColorId: Number =0;
  mrp:number =0;
  count:number =0;
  purPrice:number =0;
  discount:number =0;

  productID: string = '';
  constructor(private pmsService: PMSService  ,private router: Router, private prmsService: PrmsService) {}
  
  ngOnInit() {
    this.getCategories();
    this.getColors();
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

  onCategorySelected(categoryId: number) {
    this.selectedCategoryId = categoryId;
    this.getSizes(categoryId);
  }

  onSizeSelected(sizeID: number) {
    this.selectedSizeId = sizeID;
  }

  onColorSelected(colorID: number) {
    this.selectedColorId = colorID;
  }

  getSizes(categoryId: number) {
    this.pmsService.getSizes(categoryId).subscribe((sizes: Size[]) => {
      this.sizes = sizes;
    });
}

addPurchase()
{
  const data = {
    ProductID: this.productID,
    CategoryId: this.selectedCategoryId,
    SizeId: this.selectedSizeId,
    ColorId: this.selectedColorId,
    MRP: this.mrp,
    Count: this.count,
    PurchasePrice: this.purPrice,
    DiscountCode: this.discount,
  };

  this.prmsService.addPurchase(data).subscribe(
    (response) => {
      this.router.navigate(['Purchase'])
    },
    (error) => {
      console.error('Error sending data:', error);
    }
  );
}
}
