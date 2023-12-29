import { Component } from '@angular/core';
import { Brand } from '../../shared/Models/Brand';
import { PMSService } from '../../shared/Services/pms.service';
import {  Router } from '@angular/router';
import { PrmsService } from '../../shared/Services/prms.service';
import { Model } from '../../shared/Models/Model';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import {NgxImageCompressService} from 'ngx-image-compress';
import { Product } from '../../shared/Models/Product';
import { MatSnackBar,MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-product',
  standalone: false,
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent {
  brands: Brand[] = [];
  models: Model[] = [];
  selectedBrand:string = '';
  selectedModel: string ='';
  productID: string = '';
  productName: string = '';
  constructor(private pmsService: PMSService  ,private router: Router, private prmsService: PrmsService,private imageCompress: NgxImageCompressService, private snackBar: MatSnackBar) {}
  
  ngOnInit() {
    this.getBrands();
    this.getModels();
  }

  getBrands() {
    this.pmsService.getBrands().subscribe((brands: Brand[]) => {
      this.brands = brands;
    });
  }

  getModels() {
    this.pmsService.getModels().subscribe((models: Model[]) => {
      this.models = models;
    });
  }

  onBrandSelected(brandId: number) {
    this.selectedBrand = brandId.toString();
  }

  onModelSelected(modelID: number) {
    this.selectedModel = modelID.toString();
  }

  openSuccessMessage(message: string): void {
    this.snackBar.open(message, 'Close', {
      duration: 5000,
      verticalPosition: 'top',
      panelClass: ['success-snackbar'],
    });
  }

addProduct()
{
  const data:Product = {
    _id: '',
    productID: this.productID,
    productName: this.productName,
    brandID: parseInt(this.selectedBrand),
    modelID: parseInt(this.selectedModel),
    isActive: true,
    brand: '',
    model:''
  };

  this.pmsService.addProduct(data).subscribe(
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
