import { Component } from '@angular/core';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { HttpClientModule } from '@angular/common/http';
import { PMSService } from '../../shared/Services/pms.service';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { PAList } from '../../shared/Models/PAList';

@Component({
  selector: 'app-palist',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatTableModule,HttpClientModule,MatButtonModule,MatIconModule],
  templateUrl: './palist.component.html',
  styleUrl: './palist.component.css',
  providers:[PMSService]
})
export class PAListComponent {
  constructor (private pmsService: PMSService,private router: Router) {}
  products:PAList[] = [];
  displayedColumns: string[] = ['productID', 'Category', 'Color','Tag', 'Size','image'];
  dataSource = new MatTableDataSource<PAList>([]);

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
      });
    }
  
    viewProduct(padID:string)
    {
        this.router.navigate(['/Product',padID ]);
    }
}
