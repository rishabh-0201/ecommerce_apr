import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendorComponent } from './admin/vendor/vendor.component';
import { AppComponent } from './app.component';

const routes: Routes = [
{
  path:'vendor',
  component:VendorComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
