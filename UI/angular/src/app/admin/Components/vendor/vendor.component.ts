import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ConfirmationService } from 'primeng/api';
import { VendorService } from '../../Service/vendor.service';
import { State, Vendor } from 'src/app/Model/Model';
@Component({
  selector: 'app-vendor',
  templateUrl: './vendor.component.html',
  styles: [
    `tr.even{ 
        background-color:  #d9ebf0; 
        color: #0C2D48; 
    } 
    tr.odd{ 
        background-color: white; 
        color:#0C2D48; 
    } 
    `
  ]
})
export class VendorComponent implements OnInit {
  visible: boolean = false;
  states: State[] = [];
  cities: any[] = [];
  companies: any[] = [];
  vendor: any = {};
  vendors: any[] = [];
  selectedState: any = {
    stateId: '',
    stateName: ''
  };
                      selectedCity: any = {
    cityId: '',
    cityName: '',
    stateId: ''
  };
  selectedCompany: any = {
    companyId: '',
    companyName: ''
  };
  selectedCompanyId: any;
  selectedStateId = this.selectedState.stateId;
  constructor(private confirmationService: ConfirmationService, private vendorService: VendorService) {
    this.cities = [];
    this.companies = [];
    this.vendors = [];
  }
  ngOnInit(): void {
    this.getStates();
    this.getCompany();
    this.getVendors();
  }
  confirm() {
    this.visible = !this.visible;
  }
  getStates() {
    this.vendorService.GetStates().subscribe({
      next: (res) => {
        console.log(res);
        this.states = res;
      }
    })
  }
  getCitiesByState() {
    this.vendorService.GetCityByStateId(this.selectedState.stateId).subscribe({
      next: (res) => {
        console.log(res);
        this.cities = res
      }
    });
  }
  getCompany() {
    this.vendorService.GetCompanies().subscribe({
      next: (res) => {
        this.companies = res;
      }
    })
  }
  getVendors() {
    this.vendorService.GetVendors().subscribe({
      next: (res) => {
        this.vendors = res;
        this.vendors.forEach(x => x.isEdit = false)
        console.log(this.vendors);
      }
    })
  }
  addVendor(vendorForm: NgForm) {
    this.selectedStateId = this.selectedState.stateId
    this.selectedCompanyId = this.selectedCompany.companyId
    this.vendor = {
      vendorName: vendorForm.value.name,
      contactPerson: vendorForm.value.person,
      phoneNumber: vendorForm.value.phoneNumber,
      email: vendorForm.value.email,
      address: vendorForm.value.address,
      cityId: vendorForm.value.selectedCity.cityId,
      stateId: this.selectedStateId,
      companyId: this.selectedCompanyId
    };
    this.vendorService.PostVendor(this.vendor).subscribe({
      next: (res) => {
        console.log(res);
        this.getVendors();
      }
    })
    vendorForm.resetForm();
    this.visible = !this.visible;
  }
  updateVendor(id: number, vendor: any) {
    vendor.isEdit = !vendor.isEdit;
    this.vendorService.PutVendor(id, vendor).subscribe({
      next: (res) => {
        console.log(res);
        // this.getVendors();
      }
    })
  }
  // updateVendor(vendor: any) {
  //   vendor.isEdit = !vendor.isEdit;
  // }
  deleteVendor(id: number) {
    this.vendorService.DeleteVendor(id).subscribe({
      next: (res) => {
        this.getVendors();
      }
    })
  }
}

