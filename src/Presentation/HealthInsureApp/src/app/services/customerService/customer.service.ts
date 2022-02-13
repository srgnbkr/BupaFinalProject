import { ListResponseModel } from './../../models/base/listResponseModel';
import { ResponseModel } from './../../models/base/responseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from 'src/app/models/customer/customer';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  apiUrl = 'https://localhost:5001/api/Customers/';

  constructor(private httpClient: HttpClient) {}

  customerAdd(customer: Customer): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + 'add', customer);
  }

  customerGetAll():Observable<ListResponseModel<Customer>>{
    let newPath = this.apiUrl +"getAll";
    return this.httpClient.get<ListResponseModel<Customer>>(newPath);
  }


}
