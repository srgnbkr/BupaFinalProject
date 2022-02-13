import { ResponseModel } from './../../models/base/responseModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Insured } from 'src/app/models/insureds/insured';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class InsuredService {
  apiUrl = 'https://localhost:5001/api/Insureds/';

  constructor(private httpClient: HttpClient) {}

  addInsured(insured: Insured): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(
      this.apiUrl + 'add',
      insured
    );
  }
}
