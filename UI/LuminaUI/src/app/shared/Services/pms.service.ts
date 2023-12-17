import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductList } from '../Models/ProductList';


@Injectable({
  providedIn: 'root'
})
export class PMSService {
  private apiUrl = 'https://localhost:7117/api/PMS/GetProductList';

  constructor(private http: HttpClient) {}

  getProducts(): Observable<ProductList[]> {
    return this.http.get<ProductList[]>(this.apiUrl);
  }
}
