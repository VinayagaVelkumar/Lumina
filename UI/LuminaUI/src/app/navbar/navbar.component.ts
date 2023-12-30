import { Component, ElementRef, Renderer2 } from '@angular/core';
import { Router,ActivatedRoute  } from '@angular/router';
import { CommonService } from '../shared/Services/common.service';
import { AuthService } from '../shared/Services/auth.service';
import { PrmsService } from '../shared/Services/prms.service';

@Component({
  selector: 'app-navbar',
  standalone: false,
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  imagesCount:string = '';
  isLoggedin:boolean = false;
  displayNotification:boolean = false;
  cartCount:string = '';
  displayCart:boolean =false;
  constructor(private router:Router, private authService:AuthService,private commonService: CommonService, private route: ActivatedRoute,private el: ElementRef, private renderer: Renderer2, private prmsService:PrmsService)
  {

  }
  ngOnInit(): void {  
 this.setImage();
this.setCart();
  }

  setCart()
  {
    this.prmsService.menuProducts$.subscribe((menuProducts) => {
     if(menuProducts.length == 0)
     {
       this.cartCount = '';
       this.displayCart = false;
     }
     else
     {
     this.cartCount = menuProducts.length.toString();
     this.displayCart = true;
     }
   });
  }

  setImage()
  {
    this.commonService.setImagesCount(0); //initializing call to controller
    this.commonService.imagesCount$.subscribe((count) => {
     if(count == 0)
     {
       this.imagesCount = '';
       this.displayNotification = false;
     }
     else
     {
     this.imagesCount = count.toString();
     this.displayNotification = true;
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

  navToBill() {
    this.removeClass();
    this.router.navigate(['Bill']);
  }

  logout()
  {
       localStorage.removeItem('token');
       this.authService.setLoggedIn(false);
       this.router.navigate(['Login']);
  }
}
