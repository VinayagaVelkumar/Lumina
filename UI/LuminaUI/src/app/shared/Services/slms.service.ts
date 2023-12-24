import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class SlmsService {
  constructor(private http: HttpClient) { }
  private apiASUrl = 'https://localhost:7117/api/PRMS/AddSale';

  setproductID(data: string): void {
    localStorage.setItem("salePRId", data);
  }

  getproductID(): any {
    return localStorage.getItem("salePRId");
  }

  addSale(data: any): Observable<any> {
    return this.http.post<any>(`${this.apiASUrl}`, data);
  }
}
