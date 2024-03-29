import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatBadgeModule } from '@angular/material/badge';
import { MatTableModule } from '@angular/material/table';
import { ProductfilterComponent } from './pms/productfilter/productfilter.component';
import { PMSService } from './shared/Services/pms.service';
import { PrmsService } from './shared/Services/prms.service';
import { SlmsService } from './shared/Services/slms.service';
import { UmsService } from './shared/Services/ums.service';
import { CommonService } from './shared/Services/common.service';
import { ProductlistComponent } from './pms/productlist/productlist.component';
import { AddPADetailComponent } from './pms/add-padetail/add-padetail.component';
import { AuthService } from './shared/Services/auth.service';
import { AddProductComponent } from './pms/add-product/add-product.component';
import { PAListComponent } from './pms/palist/palist.component';
import { PMSComponent } from './pms/pms.component';
import { SLMSComponent } from './slms/slms.component';
import { ImageuploadComponent } from './pms/imageupload/imageupload.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';
import {MatMenuModule} from '@angular/material/menu';
import { Router, RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialogModule } from '@angular/material/dialog';
import { AppComponent } from './app.component';
import { routes } from './app.routes';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { httpInterceptorProviders } from './shared/Services/interceptors/token-interceptor.service';
import { AddSaleComponent } from './slms/add-sale/add-sale.component';
import { PreparepurchaseComponent } from './prms/preparepurchase/preparepurchase.component';
import { BillComponent } from './prms/bill/bill.component';
import { PdfExportService } from './shared/Services/pdf-export-service.service';
import { ProductFilterPipe } from './shared/product-filter.pipe';
import { SaleFilterPipe } from './shared/sale-filter.pipe';
import { ProductComponent } from './pms/product/product.component';
import { PRMSComponent } from './prms/prms.component';
import { SalelistComponent } from './slms/salelist/salelist.component';
import { UMSComponent } from './ums/ums.component';
import { HighlightActiveDirective } from './shared/Directives/highlight-active.directive';


@NgModule({
  declarations: [AppComponent, ProductfilterComponent,ProductlistComponent,AddPADetailComponent,AddProductComponent,PAListComponent,PMSComponent,SLMSComponent,ImageuploadComponent,NavbarComponent,LoginComponent,AddSaleComponent,
  PreparepurchaseComponent, BillComponent, ProductFilterPipe, SaleFilterPipe, ProductComponent, PRMSComponent, SalelistComponent,
  UMSComponent, HighlightActiveDirective],
  imports: [
    BrowserModule,BrowserAnimationsModule,NoopAnimationsModule,RouterModule.forRoot(routes),CommonModule,HttpClientModule,MatFormFieldModule, MatSelectModule, MatInputModule, FormsModule,HttpClientModule,MatButtonModule,MatMenuModule,MatIconModule,MatToolbarModule,MatBadgeModule,RouterModule,MatCardModule,MatSnackBarModule,MatTableModule,MatDialogModule
  ],
  providers:[PMSService,PrmsService,SlmsService,UmsService,CommonService,AuthService, httpInterceptorProviders, PdfExportService],
  bootstrap: [AppComponent]
})
export class AppModule { }
