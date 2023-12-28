import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CommonService {
  private apiImageCountURL = `${environment.pmsAPI}GetAllPADWithoutImageCount`;
  constructor(private http: HttpClient) { }
  private imagesCountSubject = new BehaviorSubject<number>(0);
  imagesCount$ = this.imagesCountSubject.asObservable();

  getImagesCount(): number {
    return this.imagesCountSubject.value;
  }

  setImagesCount(count: number): void {
    this.getImageCount().subscribe((count: number) => {
      this.imagesCountSubject.next(count);
    });
  }

  getImageCount(): Observable<number> {
    return this.http.get<number>(this.apiImageCountURL);
  }
}
