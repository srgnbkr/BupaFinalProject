import { ResponseModel } from './../../models/base/responseModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Insured } from 'src/app/models/insureds/insured';
import { Observable } from 'rxjs';
import { ListResponseModel } from 'src/app/models/base/listResponseModel';

@Injectable({
  providedIn: 'root',
})
export class InsuredService {
  apiUrl = 'https://localhost:5001/api/Insureds/';

  constructor(private httpClient: HttpClient) {}

  addInsured(insured: Insured): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + 'add', insured);
  }

  getInsuredsByCustomerId(
    customerId: number
  ): Observable<ListResponseModel<Insured>> {
    let newPath = this.apiUrl + 'getCustomerId?customerId=' + customerId;
    return this.httpClient.get<ListResponseModel<Insured>>(newPath);
  }
}
