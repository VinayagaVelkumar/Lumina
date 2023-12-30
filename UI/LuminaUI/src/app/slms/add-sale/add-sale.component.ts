import { Component } from '@angular/core';
import { SlmsService } from '../../shared/Services/slms.service';
import {MatDialogRef} from '@angular/material/dialog';
import { MatSnackBar,MatSnackBarModule } from '@angular/material/snack-bar';


@Component({
  selector: 'app-add-sale',
  standalone: false,
  templateUrl: './add-sale.component.html',
  styleUrl: './add-sale.component.css'
})
export class AddSaleComponent {
  count:string ='';
  soldPrice:string ='';

  productID: string = '';
  paID: string = '';
  MRP: string = '';
  Discount: string = '';
  availableCount: number = 0;
  
  constructor(private snackBar: MatSnackBar, private slmsService: SlmsService,public dialogRef: MatDialogRef<AddSaleComponent>) {}
  
  ngOnInit() {
    this.productID = this.slmsService.getproductID();
    this.paID = this.slmsService.getpatID();
    this.MRP = this.slmsService.getMRP();
    this.Discount = this.slmsService.getDiscount();
    this.availableCount = parseInt(this.slmsService.getCount());
  }


  closeDialog() {
    this.dialogRef.close();
  }

  onCountChange() {
    if (parseInt(this.count) > this.availableCount) {
      this.count = this.availableCount.toString();
    }
  }

  openSuccessMessage(message: string): void {
    this.snackBar.open(message, 'Close', {
      duration: 5000,
      verticalPosition: 'top',
      panelClass: ['success-snackbar'],
    });
  }

addSale()
{
  const data = {
    padID: this.paID,
    soldPrice: this.slmsService.removeLeadingZeros(parseInt(this.soldPrice)),   
    Count: this.slmsService.removeLeadingZeros(parseInt(this.count))
  };
  

  this.slmsService.addSale(data).subscribe(
    (response) => {
      this.slmsService.setSalePAList();
      this.dialogRef.close();
      this.openSuccessMessage('Successfully saved !')
    },
    (error) => {
      console.error('Error sending data:', error);
    }
  );
}
}
