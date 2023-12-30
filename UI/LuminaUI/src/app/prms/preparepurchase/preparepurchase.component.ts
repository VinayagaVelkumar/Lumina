import { Component } from '@angular/core';
import { PMSService } from '../../shared/Services/pms.service';
import { Router } from '@angular/router';
import { PAList } from '../../shared/Models/PAList';
import { MatTableDataSource } from '@angular/material/table';
import { PrmsService } from '../../shared/Services/prms.service';

@Component({
  selector: 'app-preparepurchase',
  standalone: false,
  templateUrl: './preparepurchase.component.html',
  styleUrl: './preparepurchase.component.css'
})
export class PreparepurchaseComponent {
  constructor (private prmsService: PrmsService,private router: Router) {}
  products:PAList[] = [];
  menuProducts:string [] = [];
  displayedColumns: string[] = ['productID', 'Category', 'Color','Tag', 'Size','count','image'];
  dataSource = new MatTableDataSource<PAList>([]);

  ngOnInit() {
    this.prmsService.menuProducts$.subscribe((menuProducts) => {
      this.menuProducts = menuProducts;
      this.getPAList();
    });
    }
  
    applyFilter(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
      this.dataSource.filter = filterValue.trim().toLowerCase();
    }
    getPAList() {
      this.prmsService.getPreparePurchase().subscribe((products: PAList[]) => {
        this.products = products;
        this.dataSource = new MatTableDataSource<PAList>(this.products);
        this.products.forEach(item => {
          if (!this.menuProducts.includes(item._id)) {
            item.addedToBill = false; 
          }
          else
          {
            item.addedToBill = true; 
          }
        });
      });
    }
  
    addToBill(element: PAList) {
      const isAdded = this.prmsService.addToMenuProducts(element._id);
      element.addedToBill = isAdded;
    }
    
    removeFromBill(element: PAList) {
      this.prmsService.removeFromMenuProducts(element._id);
      element.addedToBill = false;
    }

}
