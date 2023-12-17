import { Component } from '@angular/core';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [SlickCarouselModule,MatIconModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {
  receivedValue: string;
  productImages = ['1', '2', '2'];
  
  slickConfig = {
    slidesToShow: 1,
    slidesToScroll: 1
  };
  constructor(private route: ActivatedRoute,private router: Router) {
    this.receivedValue = ''
  }
  goToHome()
  {
    this.router.navigate(['' ]);
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.receivedValue = params['productID'];
    });
  
}}
