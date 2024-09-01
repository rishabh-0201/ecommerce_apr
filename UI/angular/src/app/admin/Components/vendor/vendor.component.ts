import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ConfirmationService } from 'primeng/api';
import { VendorService } from '../../Service/vendor.service';
import { State } from 'src/app/Model/Model';
@Component({
  selector: 'app-vendor',
  templateUrl: './vendor.component.html',
  styleUrls: ['./vendor.component.css']
})
export class VendorComponent implements OnInit{
  visible: boolean = false;
  isEdit:boolean=false;
  states: State[] = [];
  cities: any[] = [];
  companies: any[] = [];
  selectedStateId: number=0;
  selectedCityId: number=0;
  selectedCompanyId: number=0;
  vendors:any[]=[];
  constructor(private confirmationService: ConfirmationService , private vendorService:VendorService) {
    // this.states= [
    //   { name: 'MP', id: 1 },
    //   { name: 'UP', id: 2 },
    //   { name: 'AP', id: 3 },
    //   { name: 'Gujarat', id: 4 },
    //   { name: 'Rajasthan', id: 5 }
    // ];
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
  ngOnInit(): void {
     this.getStates();
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
 getStates(){
   this.vendorService.GetStates().subscribe({
    next:(res)=>{
      console.log(res);
    this.states=res;
   }
   })
 }
}

