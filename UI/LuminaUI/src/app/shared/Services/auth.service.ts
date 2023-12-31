import { Injectable } from '@angular/core';
import { BehaviorSubject,Observable, elementAt } from 'rxjs';
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
  private skipAuthCheckSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  skipAuthCheckSubject$ = this.skipAuthCheckSubject.asObservable();
  private userIDSubject: BehaviorSubject<number> = new BehaviorSubject<number>(0);
  userIDSubject$ = this.userIDSubject.asObservable();
  constructor(private http:HttpClient) { }

  setLoggedIn(value: boolean): void {
    if(value)
    {
    localStorage.setItem('IsLoggedIn', 'true');
    }
    else
    {
      localStorage.setItem('IsLoggedIn', 'false');
    }
    this.isLoggedInSubject.next(value);
  }

  getLoggedIn(): boolean{
    var res = localStorage.getItem('IsLoggedIn');
    if(res == 'true')
    {
      return true;
    }
    else{
     return false;
    }
  }

  setUserID(value: number): void {
    localStorage.setItem('userID', value.toString());
    this.userIDSubject.next(value);
  }

  getUserID(): Observable<number> {
    return this.userIDSubject.asObservable();
  }

  removeUserID()
  {
    localStorage.removeItem('userID');
    this.userIDSubject.next(0);
  }

  setskipAuth(value: boolean): void {
    this.skipAuthCheckSubject.next(value);
  }

  getskipAuth(): Observable<boolean> {
    return this.skipAuthCheckSubject.asObservable();
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
