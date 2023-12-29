import { Component } from '@angular/core';
import { PMSService } from '../../shared/Services/pms.service';
import { Category } from '../../shared/Models/Category';
import { Model } from '../../shared/Models/Model';
import { Size } from '../../shared/Models/Size';
import { Router } from '@angular/router';
import { ProductFilter } from '../../shared/Models/ProductFilter';
import { CommonService } from '../../shared/Services/common.service';

@Component({
  selector: 'app-productfilter',
  standalone: false,
  templateUrl: './productfilter.component.html',
  styleUrl: './productfilter.component.css'
})
export class ProductfilterComponent {
  categories: Category[] = [];
  models: Model[] = [];
  sizes: Size[] = [];
  selectedCategoryId:number = 0;
  selectedModelId:number = 0;
  selectedSizeId: number =0;
  defModel:Model =  new Model(0, 'Any', true);

  constructor(private pmsService: PMSService  ,private router: Router,private commonService:CommonService) {}
  
  ngOnInit() {
    this.getCategories();
    this.getModels();
    this.commonService.setImagesCount(0); //initializing call to controller
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
