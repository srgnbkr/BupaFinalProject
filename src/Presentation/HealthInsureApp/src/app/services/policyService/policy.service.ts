import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from 'src/app/models/base/listResponseModel';
import { Policy } from 'src/app/models/policy/policy';

@Injectable({
  providedIn: 'root'
})
export class PolicyService {

  constructor(private httpClient:HttpClient) { }

  apiUrl = 'https://localhost:5001/api/Policies/';



  getPolicies():Observable<ListResponseModel<Policy>> {
    let newPath = this.apiUrl +"getAll";
    return this.httpClient.get<ListResponseModel<Policy>>(newPath);
  }
}
