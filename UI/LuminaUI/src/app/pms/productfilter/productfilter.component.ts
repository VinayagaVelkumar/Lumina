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
import { ProductFilter } from '../../shared/Models/ProductFilter';

@Component({
  selector: 'app-productfilter',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, MatInputModule, FormsModule,HttpClientModule,MatButtonModule],
  templateUrl: './productfilter.component.html',
  styleUrl: './productfilter.component.css',
  providers: [PMSService]
})
export class ProductfilterComponent {
  categories: Category[] = [];
  models: Model[] = [];
  sizes: Size[] = [];
  selectedCategoryId:number = 0;
  selectedModelId:number = 0;
  selectedSizeId: number =0;
  defModel:Model =  new Model(0, 'Any', true);

  constructor(private pmsService: PMSService  ,private router: Router) {}
  
  ngOnInit() {
    this.getCategories();
    this.getModels();
  }

  getCategories() {
    this.pmsService.getCategories().subscribe((categories: Category[]) => {
      this.categories = categories;
    });
  }

  getModels() {
    this.pmsService.getModels().subscribe((models: Model[]) => {
      this.models = models;
      this.models.unshift(this.defModel);
    });
  }

  onCategorySelected(categoryId: number) {
    this.selectedCategoryId = categoryId;
    this.getSizes(categoryId);
  }

  onModelSelected(modelID: number) {
    this.selectedModelId = modelID;
  }

  onSizeSelected(sizeID: number) {
    this.selectedSizeId = sizeID;
  }

  getSizes(categoryId: number) {
    this.pmsService.getSizes(categoryId).subscribe((sizes: Size[]) => {
      this.sizes = sizes;
    });
}

gotoList()
{
    this.pmsService.setproductFilter(new ProductFilter(this.selectedCategoryId,this.selectedSizeId,this.selectedModelId));
    this.router.navigate(['List']);
}
}
