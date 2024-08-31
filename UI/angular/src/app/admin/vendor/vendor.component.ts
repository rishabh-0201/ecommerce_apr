import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-vendor',
  templateUrl: './vendor.component.html',
  styleUrls: ['./vendor.component.css']
})
export class VendorComponent {
  visible: boolean = false;
  isEdit:boolean=false;
  cities: any[] = [];
  companies: any[] = [];
  selectedCityId: number=0;
  selectedCompanyId: number=0;
  vendors:any[]=[];
  constructor(private confirmationService: ConfirmationService) {
    this.cities = [
      { name: 'New York', id: 1 },
      { name: 'Rome', id: 2 },
      { name: 'London', id: 3 },
      { name: 'Istanbul', id: 4 },
      { name: 'Paris', id: 5 }
    ];
    this.companies= [
      { name: 'Vivo', id: 1 },
      { name: 'Oppo', id: 2 },
      { name: 'Samsung', id: 3 },
      { name: 'Mi', id: 4 },
      { name: 'IPhone', id: 5 }
    ];
      this.vendors= [
        {id:1, name: 'Anupam ', number:'2364764634',city:'indore',company:'vivo'},
        { id:2,name: 'Aastha ', number:'2364764634',city:'dewas',company:'oppo'},
        { id:3,name: 'Mansi', number:'2364764634',city:'ujjain',company:'samsung'},
        { id:4,name: 'Iccha', number:'2364764634',city:'bhopal',company:'iphone'},
    ];
  }

  confirm() {
    this.visible = !this.visible;
  }

  onSubmit(form: NgForm) {
    console.log(form.value);
    this.visible=!this.visible;
    form.resetForm();
 }
 updateVendor(){
    this.isEdit=!this.isEdit;
 }
}
