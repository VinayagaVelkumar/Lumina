import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatBadgeModule } from '@angular/material/badge';
import {MatSelectModule} from '@angular/material/select';
import {MatMenuModule} from '@angular/material/menu';
import { Router } from '@angular/router';
import { CommonService } from '../shared/Services/common.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [MatToolbarModule,MatButtonModule,MatIconModule,MatBadgeModule,HttpClientModule,MatSelectModule,MatMenuModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
  providers: [CommonService]
})
export class NavbarComponent {
  imagesCount:string = '';
  constructor(private router:Router, private commonService: CommonService)
  {

  }
  ngOnInit(): void {  
   this.commonService.imagesCount$.subscribe((count) => {
    if(count == 0)
    {
      this.imagesCount = '';
    }
    else
    {
    this.imagesCount = count.toString();
    }
  });
  this.commonService.setImagesCount(0);
  }
  navtoHome() {
    this.router.navigate(['']);
  }

  navtoPurchase() {
    this.router.navigate(['Purchase']);
  }

  navtoImageUpload() {
    this.router.navigate(['AddImages']);
  }

  navToProducts() {
    this.router.navigate(['Products']);
  }

  navToSales() {
    this.router.navigate(['Sale']);
  }
}
