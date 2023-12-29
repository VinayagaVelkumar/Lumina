import { Component } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { SlmsService } from '../../shared/Services/slms.service';
import {MatDialog, MatDialogModule,MatDialogRef} from '@angular/material/dialog';
import { MatSnackBar,MatSnackBarModule } from '@angular/material/snack-bar';


@Component({
  selector: 'app-add-sale',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, MatInputModule, FormsModule,HttpClientModule,MatButtonModule,MatSnackBarModule],
  templateUrl: './add-sale.component.html',
  styleUrl: './add-sale.component.css',
  providers: [SlmsService]
})
export class AddSaleComponent {
  count:string ='';
  soldPrice:string ='';

  productID: string = '';
  constructor(private snackBar: MatSnackBar, private slmsService: SlmsService,public dialogRef: MatDialogRef<AddSaleComponent>) {}
  
  ngOnInit() {
    this.productID = this.slmsService.getproductID();
  }

  closeDialog() {
    this.dialogRef.close();
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
    padID: this.productID,
    soldPrice: this.slmsService.removeLeadingZeros(parseInt(this.soldPrice)),   
    Count: this.slmsService.removeLeadingZeros(parseInt(this.count))
  };
  

  this.slmsService.addSale(data).subscribe(
    (response) => {
      this.dialogRef.close();
      this.openSuccessMessage('Successfully saved !')
    },
    (error) => {
      console.error('Error sending data:', error);
    }
  );
}
}
