import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListResponseModel } from 'src/app/models/base/listResponseModel';
import { PaymentType } from 'src/app/models/paymentType/paymentType';

@Injectable({
  providedIn: 'root',
})
export class PaymentTypeService {
  apiUrl = 'https://localhost:5001/api/PaymentTypes/';

  constructor(private httpClient: HttpClient) {}

  getAllPaymentType(): Observable<ListResponseModel<PaymentType>> {
    let newPath = this.apiUrl + 'getAll';
    return this.httpClient.get<ListResponseModel<PaymentType>>(newPath);
  }
}
