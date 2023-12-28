import { Component, ElementRef, Renderer2 } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatBadgeModule } from '@angular/material/badge';
import {MatSelectModule} from '@angular/material/select';
import {MatMenuModule} from '@angular/material/menu';
import { Router,ActivatedRoute,RouterModule  } from '@angular/router';
import { CommonService } from '../shared/Services/common.service';
import { HttpClientModule } from '@angular/common/http';
import { HighlightActiveDirective } from '../shared/Directives/highlight-active.directive';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [MatToolbarModule,MatButtonModule,MatIconModule,MatBadgeModule,HttpClientModule,MatSelectModule,MatMenuModule,RouterModule,HighlightActiveDirective],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
  providers: [CommonService]
})
export class NavbarComponent {
  imagesCount:string = '';
  constructor(private router:Router, private commonService: CommonService, private route: ActivatedRoute,private el: ElementRef, private renderer: Renderer2)
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

  removeClass() {
    const buttonToModify = this.el.nativeElement.querySelector('#prButton');
    this.renderer.removeClass(buttonToModify, 'activenavbar');
  }

  navtoHome() {
    this.removeClass();
    this.router.navigate(['']);
  }

  navtoPurchase() {
    this.router.navigate(['Purchase']);
  }

  navtoImageUpload() {
    this.removeClass();
    this.router.navigate(['AddImages']);
  }

  navToProducts() {
    this.removeClass();
    this.router.navigate(['Products']);
  }

  navToSales() {
    this.removeClass();
    this.router.navigate(['Sale']);
  }
}
