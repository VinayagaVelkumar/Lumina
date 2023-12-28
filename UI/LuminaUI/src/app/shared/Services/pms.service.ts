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
import { PAList } from '../Models/PAList';
import { ProductFilter } from '../Models/ProductFilter';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PMSService {
  private apiPLUrl = `${environment.pmsAPI}GetProductList`;
  private apiPRByIDUrl = `${environment.pmsAPI}GetProductByID`;
  private apiCategoryUrl = `${environment.pmsAPI}GetCategories`;
  private apiSizeUrl = `${environment.pmsAPI}GetSizes`;
  private apiModelUrl = `${environment.pmsAPI}GetModels`;
  private apiColorUrl = `${environment.pmsAPI}GetColors`;
  private apiTagUrl = `${environment.pmsAPI}GetTags`;
  private apiAddProductUrl = `${environment.pmsAPI}InsertProduct`;
  private apiBrandUrl = `${environment.pmsAPI}GetBrands`;
  private apiPAListUrl = `${environment.pmsAPI}GetAllPAD`; 
  private apiPAImageUrl = `${environment.pmsAPI}GetAllPADWithoutImage`; 
  private apiPAImageUploadURL = `${environment.pmsAPI}UpdatePAImage`; 

  constructor(private http: HttpClient) {}

  getProducts(CategoryID:number,ModelID:number,SizeID:number): Observable<ProductList[]> {
    const urlWithParams = `${this.apiPLUrl}?categoryID=${CategoryID}&modelID=${ModelID}&sizeID=${SizeID}`;
    return this.http.get<ProductList[]>(urlWithParams);
  }

  getProductByID(padID:string): Observable<ProductList> {
    const urlWithParams = `${this.apiPRByIDUrl}?id=${padID}`;
    return this.http.get<ProductList>(urlWithParams);
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

  getPAImage(): Observable<PAList[]> {
    return this.http.get<PAList[]>(this.apiPAImageUrl);
  }

  getPAList(): Observable<PAList[]> {
    return this.http.get<PAList[]>(this.apiPAListUrl);
  }

  setproductFilter(data: ProductFilter): void {
    localStorage.setItem("selCatID", data.categoryID.toString());
    localStorage.setItem("selModelID", data.modelID.toString());
    localStorage.setItem("selSizeID", data.sizeID.toString());
  }

  getproductFilter(): ProductFilter {
    const selCatIDString: string | null = localStorage.getItem("selCatID");
    const selCatID: number = selCatIDString ? parseInt(selCatIDString, 10) : 0;
    const selModelIDString: string | null = localStorage.getItem("selModelID");
    const selModelID: number = selModelIDString ? parseInt(selModelIDString, 10) : 0;
    const selSizeIDString: string | null = localStorage.getItem("selSizeID");
    const selSizeID: number = selSizeIDString ? parseInt(selSizeIDString, 10) : 0;
    return new ProductFilter(selCatID,selSizeID,selModelID);
  }

  UploadImage(productID:string, categoryID:number, colorID: number, image:File | null): Observable<boolean> {
    const queryParams = `?categoryID=${categoryID}&productID=${productID}&colorID=${colorID}`;
    const formData: FormData = new FormData();
    if (image) {
      formData.append('image', image, image.name);
    }
    
    return this.http.put<boolean>(`${this.apiPAImageUploadURL}${queryParams}`, formData);
  }

   removeLeadingZeros(value: number): number {
    // Convert the number to a string and remove leading zeros
    const stringValue = value.toString().replace(/^0+/, '');
  
    // Convert the string back to a number
    const result = parseInt(stringValue, 10);
  
    return isNaN(result) ? 0 : result;
  }
}
