import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { SalePAList } from '../Models/SalePAList';

@Injectable({
  providedIn: 'root'
})
export class SlmsService {
  constructor(private http: HttpClient) { }
  private apiASUrl = `${environment.slmsAPI}AddSale`;
  private apiSPAListUrl = `${environment.slmsAPI}GetSalePAList`;
  private salePAList: BehaviorSubject<SalePAList[]> = new BehaviorSubject<SalePAList[]>([]);
  salePAList$ = this.salePAList.asObservable();

  setSalePAList(): void {
    this.getPAList().subscribe((products: SalePAList[]) => {
      this.salePAList.next(products);
    });
  }

  getSalePAList(): Observable<SalePAList[]> {
    return this.salePAList.asObservable();
  }
  setproductID(data: string, productID:string,mrp:string,discount:string,count:string): void {
    localStorage.setItem("salePAId", data);
    localStorage.setItem("salePRId", productID);
    localStorage.setItem("saleMRP", mrp);
    localStorage.setItem("saleDiscount", discount);
    localStorage.setItem("saleCount", count);
  }

  getproductID(): any {
    return localStorage.getItem("salePRId");
  }

  getpatID(): any {
    return localStorage.getItem("salePAId");
  }

  getMRP(): any {
    return localStorage.getItem("saleMRP");
  }

  getDiscount(): any {
    return localStorage.getItem("saleDiscount");
  }

  getCount(): any {
    return localStorage.getItem("saleCount");
  }

  getPAList(): Observable<SalePAList[]> {
    return this.http.get<SalePAList[]>(this.apiSPAListUrl);
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
