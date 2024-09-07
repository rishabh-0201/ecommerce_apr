import { Injectable } from '@angular/core';
import { environment } from 'src/environment/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Vendor } from 'src/app/Model/Model';
@Injectable({
  providedIn: 'root'
})
export class VendorService {
  url:string = environment.baseUrl;
  constructor(private http:HttpClient) { }

  GetStates():Observable<any[]>{
    return this.http.get<any[]>(this.url+"/api/State");
  }
  GetCityByStateId(stateId :number):Observable<any[]>{
    console.log(stateId)
    return this.http.get<any[]>(this.url+"/api/City/state/"+stateId)
  }
  GetCompanies():Observable<any[]>{
    return this.http.get<any[]>(this.url+"/api/Company")
  }
  PostVendor(vendor:Vendor):Observable<any>{
    return this.http.post(this.url+"/api/Vendor",vendor,{responseType:'text'})
  }
  GetVendors():Observable<any[]>{
    return this.http.get<any[]>(this.url+"/api/Vendor");
  }
  DeleteVendor(id:number):Observable<any>{
    return this.http.delete<any>(this.url+"/api/Vendor/"+id)
  }
  PutVendor(id:number,vendor:any){

    return this.http.put<any>(this.url+"/api/vendor/"+id,vendor);
  }
}
