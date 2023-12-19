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

@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [FormsModule, MatInputModule, MatSelectModule, MatFormFieldModule,HttpClientModule,MatButtonModule],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css',
  providers: [PMSService,PrmsService]
})
export class AddProductComponent {
  brands: Brand[] = [];
  models: Model[] = [];
  selectedBrand:number = 0;
  selectedModel: number =0;
  productID: string = '';
  productName: string = '';
  image: File | null =null ;
  constructor(private pmsService: PMSService  ,private router: Router, private prmsService: PrmsService,private imageCompress: NgxImageCompressService) {}
  
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
    this.selectedBrand = brandId;
  }

  onModelSelected(modelID: number) {
    this.selectedModel = modelID;
  }

  onImageSelected(event: any): void {
    const file = event.target.files[0];
    if (file) {
      this.compressImage(file);
    }
  }

  compressImage(file: File): void {
    const reader = new FileReader();

    reader.onload = (e: any) => {
      this.imageCompress.compressFile(e.target.result, -1, 50, 50).then((result) => {
        const compressedImage = new File([result], file.name, { type: file.type });
        this.image = compressedImage;
      });
    };

    reader.readAsDataURL(file);
  }
addProduct()
{
  const data:Product = {
    _id: '',
    productID: this.productID,
    productName: this.productName,
    brandID: this.selectedBrand,
    modelID: this.selectedModel,
    image: this.image?.name.split('.')[0],
    isActive: true,
    brand: '',
    model:''
  };

  this.pmsService.addProduct(data).subscribe(
    (response) => {
      this.router.navigate(['Purchase'])
    },
    (error) => {
      console.error('Error sending data:', error);
    }
  );
}
}
