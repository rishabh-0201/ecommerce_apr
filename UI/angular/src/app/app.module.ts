import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {SidebarModule} from 'primeng/sidebar';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VendorComponent } from './admin/Components/vendor/vendor.component';
import { SidebarComponent } from './common/sidebar/sidebar.component';
import { NavbarComponent } from './common/navbar/navbar.component';
import {ButtonModule} from 'primeng/button';
import { HomeComponent } from './admin/Components/home/home.component';
import {DropdownModule} from 'primeng/dropdown';
import { DialogModule } from 'primeng/dialog';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import {ConfirmationService} from 'primeng/api';
import {TableModule} from 'primeng/table';
import { HttpClientModule } from '@angular/common/http';
import { ProductComponent } from './admin/Components/product/product.component';
@NgModule({
  declarations: [
    AppComponent,
    VendorComponent,
    SidebarComponent,
    NavbarComponent,
    HomeComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,SidebarModule,BrowserAnimationsModule,ButtonModule,ConfirmDialogModule,DialogModule,DropdownModule,FormsModule,TableModule,HttpClientModule 
  ],
  providers: [ConfirmationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
