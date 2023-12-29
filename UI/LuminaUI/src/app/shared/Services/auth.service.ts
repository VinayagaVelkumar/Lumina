import { Injectable } from '@angular/core';
import { BehaviorSubject,Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiLoginURL = `${environment.umsAPI}Login`;
  private apiAuthURL = `${environment.umsAPI}AuthenticateToken`;
  private isLoggedInSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  isLoggedIn$ = this.isLoggedInSubject.asObservable();
  constructor(private http:HttpClient) { }

  setLoggedIn(value: boolean): void {
    this.isLoggedInSubject.next(value);
  }

  getLoggedIn(): Observable<boolean> {
    return this.isLoggedInSubject.asObservable();
  }

  authenticated(): boolean
  {
    const isLoggedIn = this.isLoggedInSubject.value;
    return isLoggedIn === true;
  }

  Login(data: any): Observable<any> {
    return this.http.post<any>(`${this.apiLoginURL}`, data);
  }

  authorize(): Observable<boolean> {
    return this.http.get<boolean>(this.apiAuthURL);
  }
}
