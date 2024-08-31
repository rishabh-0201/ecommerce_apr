import { Component } from '@angular/core';
import { Confirmation, ConfirmationService } from 'primeng/api';
import { City } from 'src/app/Model/City';

@Component({
  selector: 'app-vendor',
  templateUrl: './vendor.component.html',
  styleUrls: ['./vendor.component.css']
})
export class VendorComponent {
 model={
   name:'',
   number:'',
   selectedCityId:'',
 }
visible:boolean = false;
cities: City[];
selectedCityId: number=0;

  constructor(private _confirm:ConfirmationService ) {
  
    this.cities = [
      {name: 'New York', id:1 },
      {name: 'Rome', id: 2},
      {name: 'London', id: 3},
      {name: 'Istanbul', id: 4},
      {name: 'Paris', id: 5}
    ];
  }
  confirm() {
  
    this.visible  = !this.visible;
    // this._confirm.confirm({
    //   message: 'Are you sure that you want to perform this action?',
    //   accept: () => {
       
    //   }
  // });

    }
    onSubmit(){
      console.log(this.model)
    }
}
