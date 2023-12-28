import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SlmsService {
  constructor(private http: HttpClient) { }
  private apiASUrl = `${environment.slmsAPI}AddSale`;

  setproductID(data: string): void {
    localStorage.setItem("salePRId", data);
  }

  getproductID(): any {
    return localStorage.getItem("salePRId");
  }

  removeLeadingZeros(value: number): number {
    // Convert the number to a string and remove leading zeros
    const stringValue = value.toString().replace(/^0+/, '');
  
    // Convert the string back to a number
    const result = parseInt(stringValue, 10);
  
    return isNaN(result) ? 0 : result;
  }

  addSale(data: any): Observable<any> {
    return this.http.post<any>(`${this.apiASUrl}`, data);
  }
}
