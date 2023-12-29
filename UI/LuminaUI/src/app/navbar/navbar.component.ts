import { Component, ElementRef, Renderer2 } from '@angular/core';
import { Router,ActivatedRoute  } from '@angular/router';
import { CommonService } from '../shared/Services/common.service';
import { Observable } from 'rxjs';
import { AuthService } from '../shared/Services/auth.service';

@Component({
  selector: 'app-navbar',
  standalone: false,
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  imagesCount:string = '';
  isLoggedin:boolean = false;
  constructor(private router:Router, private authService:AuthService,private commonService: CommonService, private route: ActivatedRoute,private el: ElementRef, private renderer: Renderer2)
  {

  }
  ngOnInit(): void {  
   this.commonService.setImagesCount(0); //initializing call to controller
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

  this.authService.isLoggedIn$.subscribe((result) => {
    this.isLoggedin = result;
  });
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

  logout()
  {
       localStorage.removeItem('token');
       this.authService.setLoggedIn(false);
       this.router.navigate(['Login']);
  }
}
