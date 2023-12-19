import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductList } from '../Models/ProductList';
import { Category } from '../Models/Category';
import { Model } from '../Models/Model';
import { Size } from '../Models/Size';
import { Color } from '../Models/Color';
import { Tag } from '../Models/Tag';
import { Product } from '../Models/Product';
import { Brand } from '../Models/Brand';


@Injectable({
  providedIn: 'root'
})
export class PMSService {
  private apiPLUrl = 'https://localhost:7117/api/PMS/GetProductList';
  private apiCategoryUrl = 'https://localhost:7117/api/PMS/GetCategories';
  private apiSizeUrl = 'https://localhost:7117/api/PMS/GetSizes';
  private apiModelUrl = 'https://localhost:7117/api/PMS/GetModels';
  private apiColorUrl = 'https://localhost:7117/api/PMS/GetColors';
  private apiTagUrl = 'https://localhost:7117/api/PMS/GetTags';
  private apiAddProductUrl = 'https://localhost:7117/api/PMS/InsertProduct';
  private apiBrandUrl = 'https://localhost:7117/api/PMS/GetBrands';

  constructor(private http: HttpClient) {}

  getProducts(CategoryID:number,ModelID:number,SizeID:number): Observable<ProductList[]> {
    const urlWithParams = `${this.apiPLUrl}?categoryID=${CategoryID}&modelID=${ModelID}&sizeID=${SizeID}`;
    return this.http.get<ProductList[]>(urlWithParams);
  }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiCategoryUrl);
  }

  getModels(): Observable<Model[]> {
    return this.http.get<Model[]>(this.apiModelUrl);
  }

  getSizes(CategoryID:Number): Observable<Size[]> {
    const urlWithParams = `${this.apiSizeUrl}?categoryID=${CategoryID}`
    return this.http.get<Size[]>(urlWithParams);
  }

  getColors(): Observable<Color[]> {
    return this.http.get<Color[]>(this.apiColorUrl);
  }

  getTags(): Observable<Tag[]> {
    return this.http.get<Tag[]>(this.apiTagUrl);
  }

  getBrands(): Observable<Brand[]> {
    return this.http.get<Brand[]>(this.apiBrandUrl);
  }

  addProduct(data: Product): Observable<any> {
    return this.http.post<any>(`${this.apiAddProductUrl}`, data);
  }
}
