import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendorComponent } from './admin/Components/vendor/vendor.component';
import { HomeComponent } from './admin/Components/home/home.component';
import { ProductComponent } from './admin/Components/product/product.component';

const routes: Routes = [
  {
  path:'vendor',
  component:VendorComponent
},{
  path: 'Product',
  component: ProductComponent
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
