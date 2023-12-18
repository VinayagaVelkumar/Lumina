import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../Models/Product';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PrmsService {
  private productID = new BehaviorSubject<string>('');
  private apiPLUrl = 'https://localhost:7117/api/PMS/GetProducts';
  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiPLUrl);
  }

  setproductID(data: string): void {
    debugger
    this.productID.next(data);
  }

  getproductID(): Observable<string> {
    debugger
    return this.productID.asObservable();
  }
}
