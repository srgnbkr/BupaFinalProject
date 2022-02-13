import { ResponseModel } from './../../models/base/responseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Payment } from 'src/app/models/payment/payment';

@Injectable({
  providedIn: 'root',
})
export class PaymentService {
  apiUrl = 'https://localhost:5001/api/Payments/';

  constructor(private httpClient: HttpClient) {}

  addPayment(payment: Payment): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + 'add', payment);
  }
}
