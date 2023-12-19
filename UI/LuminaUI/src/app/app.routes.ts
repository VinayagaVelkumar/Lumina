import { Routes } from '@angular/router';
import { ProductlistComponent } from './pms/productlist/productlist.component';
import { ProductComponent } from './pms/product/product.component';
import { ProductfilterComponent } from './pms/productfilter/productfilter.component';
import { PRMSComponent } from './prms/prms.component';
import { AddPADetailComponent } from './pms/add-padetail/add-padetail.component';
import { AddProductComponent } from './pms/add-product/add-product.component';

export const routes: Routes = [
    { path: '', component: ProductfilterComponent },
    { path:'Product/:productID', component: ProductComponent },
    { path:'List/:categoryID/:modelID/:sizeID', component: ProductlistComponent},
    { path:'Purchase', component: PRMSComponent},
    { path:'AddPADetail', component: AddPADetailComponent},
    { path:'AddProduct', component: AddProductComponent}
];
