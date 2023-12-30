import { Component } from '@angular/core';
import { PdfExportService } from '../../shared/Services/pdf-export-service.service';
import { PrmsService } from '../../shared/Services/prms.service';
import { MatTableDataSource } from '@angular/material/table';
import { BillPAList } from '../../shared/Models/BillPAList';

@Component({
  selector: 'app-bill',
  standalone: false,
  templateUrl: './bill.component.html',
  styleUrl: './bill.component.css'
})
export class BillComponent {
  product: BillPAList[] = [];
  totalAmount:number = 0;
  displayedColumns: string[] = ['productID', 'Category', 'Color', 'Sizes','Count', 'LastPurchasePrice','EstimatedPrice'];
  dataSource = new MatTableDataSource<BillPAList>([]);
  
  constructor(private pdfExportService: PdfExportService, private prmsService:PrmsService) {}
  ngOnInit() {
    this.getProducts()
    }

    getProducts()
    {
      this.prmsService.getBillProducts().subscribe((products: BillPAList[]) => {
        this.product = products;
        this.dataSource = new MatTableDataSource<BillPAList>(this.product);
        this.totalAmount = this.product[0].estimatedTotalPrice;
      });
    }

  exportToPdf() {
    const currentDate = new Date();
    const formattedDate = this.formatDate(currentDate);
    const fileName = `billmenu_${formattedDate}`;

    this.pdfExportService.exportToPdf('billmenu', fileName);
  }

  private formatDate(date: Date): string {
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const year = date.getFullYear();
    return `${day}_${month}_${year}`;
  }
}
