import { Injectable } from '@angular/core';
import html2canvas from 'html2canvas';
import * as jspdf from 'jspdf';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { PrmsService } from './prms.service';

@Injectable({
  providedIn: 'root',
})
export class PdfExportService {
  private apiBillURL = `${environment.prmsAPI}UploadBillMenu`;
  constructor(private http: HttpClient,private prmsService:PrmsService) {}

  exportToPdf(elementId: string, fileName: string) {
    const element = document.getElementById(elementId);

    if (element) {
      html2canvas(element).then((canvas) => {
        const imgData = canvas.toDataURL('image/png');
        const pdf = new jspdf.jsPDF();
        pdf.addImage(imgData, 'PNG',0,0,0,0);

        const pdfBlob = pdf.output('blob');
        const formData = new FormData();
        formData.append('file', pdfBlob, `${fileName}.pdf`);
        this.http.post<Boolean[]>(`${this.apiBillURL}`, formData).subscribe(response => {
          this.prmsService.ClearMenuCart();
  }, error => {
  });
      });
  }
}
}
