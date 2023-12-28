import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../Models/Product';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PrmsService {
  private apiPLUrl = `${environment.pmsAPI}GetProducts`;
  private apiAPUrl = `${environment.prmsAPI}AddPurchase`;
  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiPLUrl);
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
}
