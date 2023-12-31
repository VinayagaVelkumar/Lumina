import { Injectable } from '@angular/core';
import html2canvas from 'html2canvas';
import * as jspdf from 'jspdf';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { PrmsService } from './prms.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class PdfExportService {
  private apiBillURL = `${environment.prmsAPI}UploadBillMenu`;
  constructor(private http: HttpClient,private prmsService:PrmsService, private router:Router, private snackBar:MatSnackBar) {}

  async exportToPdf(elementId: string, fileName: string) {
    const element = document.getElementById(elementId);

    if (element) {
      html2canvas(element).then(async (canvas) => {
        const imageDataURL =canvas.toDataURL('image/png');

    const response = await fetch(imageDataURL);
    const blob = await response.blob();
        const formData = new FormData();
        formData.append('file', blob, `${fileName}.png`);
        this.http.post<any>(`${this.apiBillURL}`, formData).subscribe(
        (result: boolean) => {
          if (result) {
            this.prmsService.ClearMenuCart();
            this.router.navigate([''])
            this.snackBar.open('Succesfully prepared!', 'Close', {
              duration: 5000,
              verticalPosition: 'top',
              panelClass: ['success-snackbar'],
            });
          } else {
          }
        },
        (error) => {
        }
      );
      });
  }
}
}
