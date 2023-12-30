import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../Models/Product';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { PAList } from '../Models/PAList';
import { BillPAList } from '../Models/BillPAList';

@Injectable({
  providedIn: 'root'
})
export class PrmsService {
  private apiPLUrl = `${environment.pmsAPI}GetProducts`;
  private apiPMUrl = `${environment.pmsAPI}PreparePurchase`;
  private apiAPUrl = `${environment.prmsAPI}AddPurchase`;
  private apiBPUrl = `${environment.prmsAPI}GetBillProducts`;
  private menuProductsSubject: BehaviorSubject<string[]> = new BehaviorSubject<string[]>([]);
  menuProducts$: Observable<string[]> = this.menuProductsSubject.asObservable();

  constructor(private http: HttpClient) {
    const menuItems =localStorage.getItem('menuProducts') || undefined;
    
    if(menuItems)
    {
    const storedMenuProducts = JSON.parse(menuItems) || [];
    this.menuProductsSubject = new BehaviorSubject<string[]>(storedMenuProducts);
    this.menuProducts$ = this.menuProductsSubject.asObservable();
    }
    else
    {
      this.menuProductsSubject = new BehaviorSubject<string[]>([]);
      this.menuProducts$ = this.menuProductsSubject.asObservable();
    }
   }
 ClearMenuCart()
 {
  localStorage.removeItem('menuProducts');
  this.menuProductsSubject = new BehaviorSubject<string[]>([]);
  this.menuProducts$ = this.menuProductsSubject.asObservable();
 }
  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiPLUrl);
  }

  getBillProducts(): Observable<BillPAList[]> {
    const requestPayload = this.menuProductsSubject.value;
  return this.http.post<BillPAList[]>(this.apiBPUrl, requestPayload);
  }

  getPreparePurchase(): Observable<PAList[]> {
    return this.http.get<PAList[]>(this.apiPMUrl);
  }

  setproductID(data: string): void {
    localStorage.setItem("productID", data);
  }

  getproductID(): any {
    return localStorage.getItem("productID");
  }

  addPurchase(data: any): Observable<any> {
    return this.http.post<any>(`${this.apiAPUrl}`, data);
  }

  
  private updateMenuProducts(menuProducts: string[]) {
    this.menuProductsSubject.next(menuProducts);
    localStorage.setItem('menuProducts', JSON.stringify(menuProducts));
  }

  addToMenuProducts(productId: string):boolean {
    const currentMenuProducts = this.menuProductsSubject.value;
    if (!currentMenuProducts.includes(productId)) {
      const updatedMenuProducts = [...currentMenuProducts, productId];
      this.updateMenuProducts(updatedMenuProducts);
      return true;
    }
    else
    {
      return false;
    }
  }

  removeFromMenuProducts(productId: string) {
    const currentMenuProducts = this.menuProductsSubject.value;
    const updatedMenuProducts = currentMenuProducts.filter(id => id !== productId);
    this.updateMenuProducts(updatedMenuProducts);
  }
}
