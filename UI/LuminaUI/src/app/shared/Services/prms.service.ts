import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../Models/Product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PrmsService {
  private apiPLUrl = 'https://localhost:7117/api/PMS/GetProducts';
  private apiAPUrl = 'https://localhost:7117/api/PMS/AddPurchase';
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
