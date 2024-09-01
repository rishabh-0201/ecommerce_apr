import { Injectable } from '@angular/core';
import { environment } from 'src/environment/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class VendorService {
  url:string = environment.baseUrl;
  constructor(private http:HttpClient) { }

  GetStates():Observable<any[]>{
    return this.http.get<any[]>(this.url+"/api/State");
  }
}
