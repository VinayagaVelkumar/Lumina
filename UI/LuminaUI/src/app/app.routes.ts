import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component'; 
import { ProductComponent } from './pms/product/product.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path:'Product/:productID', component: ProductComponent }
];
