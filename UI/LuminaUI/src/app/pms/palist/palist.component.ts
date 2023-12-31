import { Component } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import { PMSService } from '../../shared/Services/pms.service';
import { Router } from '@angular/router';
import { PAList } from '../../shared/Models/PAList';

@Component({
  selector: 'app-palist',
  standalone: false,
  templateUrl: './palist.component.html',
  styleUrl: './palist.component.css'
})
export class PAListComponent {
  constructor (private pmsService: PMSService,private router: Router) {}
  products:PAList[] = [];
  displayedColumns: string[] = ['productID', 'Category', 'Color','Tag', 'Size','image'];
  dataSource = new MatTableDataSource<PAList>([]);

  filterOptions: { category: string[], color: string[], size: string[] } = {
    category: [],
    color: [],
    size: []
  };
  categoryFilterValue:string ='';
  sizeFilterValue:string = '';
  colorFilterValue:string =  '';

  ngOnInit() {
    this.getPAList()
    }
  
    applyFilter(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
      this.dataSource.filter = filterValue.trim().toLowerCase();
    }

    getPAList() {
      this.pmsService.getPAList().subscribe((products: PAList[]) => {
        this.products = products;
        this.dataSource = new MatTableDataSource<PAList>(this.products);

        this.filterOptions.category = Array.from(new Set(this.products.map(item => item.category)));
    this.filterOptions.color = Array.from(new Set(this.products.map(item => item.color)));
    this.filterOptions.size = Array.from(new Set(this.products.map(item => item.size.toString())));
      });
    }
    applyCategoryFilter(category: string) {
      this.dataSource.filter = category.trim().toLowerCase();
    }
    
    applyColorFilter(color: string) {
      this.dataSource.filter = color.trim().toLowerCase();
    }
    
    applySizeFilter(size: string) {
      this.dataSource.filter = size.trim().toLowerCase();
    }
    viewProduct(padID:string)
    {
        this.router.navigate(['/Product',padID ]);
    }
}
