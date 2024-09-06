import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url:string = environment.baseUrl;
  constructor(private http:HttpClient) { 
  
  }
  GetCategories():Observable<any[]>{

    return this.http.get<any[]>(this.url+"/api/Category")
  }
  GetColor():Observable<any[]>{
    return this.http.get<any[]>(this.url+"/api/Product/Color")
  }
  GetRom():Observable<any[]>{
    return this.http.get<any[]>(this.url+"/api/Product/Rom")
  }
  GetRam():Observable<any[]>{
    return this.http.get<any[]>(this.url+"/api/Product/Ram")
  }
  GetProcessor():Observable<any[]>{
    return this.http.get<any[]>(this.url+"/api/Product/Processor")
  }
  addProduct(product:any):Observable<any>{
    return this.http.post(this.url+"/api/product",product,{responseType:'text'})
     
  }
}

