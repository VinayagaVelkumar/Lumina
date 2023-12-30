import { Routes } from '@angular/router';
import { ProductlistComponent } from './pms/productlist/productlist.component';
import { ProductComponent } from './pms/product/product.component';
import { ProductfilterComponent } from './pms/productfilter/productfilter.component';
import { PRMSComponent } from './prms/prms.component';
import { AddPADetailComponent } from './pms/add-padetail/add-padetail.component';
import { AddProductComponent } from './pms/add-product/add-product.component';
import { ImageuploadComponent } from './pms/imageupload/imageupload.component';
import { PAListComponent } from './pms/palist/palist.component';
import { SLMSComponent } from './slms/slms.component';
import { AddSaleComponent } from './slms/add-sale/add-sale.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './shared/Services/auth.guard';
import { PreparepurchaseComponent } from './prms/preparepurchase/preparepurchase.component';
import { BillComponent } from './prms/bill/bill.component';

export const routes: Routes = [
    { path: '', component: ProductfilterComponent,canActivate:[AuthGuard] },
    { path:'Product/:productID', component: ProductComponent,canActivate:[AuthGuard]},
    { path:'List', component: ProductlistComponent,canActivate:[AuthGuard]},
    { path:'Purchase', component: PRMSComponent,canActivate:[AuthGuard]},
    { path:'AddPADetail', component: AddPADetailComponent,canActivate:[AuthGuard]},
    { path:'AddProduct', component: AddProductComponent,canActivate:[AuthGuard]},
    { path:'AddImages', component: ImageuploadComponent,canActivate:[AuthGuard]},
    { path:'Products', component: PAListComponent,canActivate:[AuthGuard]},
    { path:'Sale', component: SLMSComponent,canActivate:[AuthGuard]},
    { path:'AddSale', component: AddSaleComponent,canActivate:[AuthGuard]},
    { path:'PreparePurchase', component: PreparepurchaseComponent,canActivate:[AuthGuard]},
    { path:'Bill', component: BillComponent,canActivate:[AuthGuard]},
    { path:'Login', component: LoginComponent}
];
