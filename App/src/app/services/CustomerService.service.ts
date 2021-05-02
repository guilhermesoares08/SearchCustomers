import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Customer } from '../_models/Customer';
import { Filter } from '../_models/Filter';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  baseUrl = environment.apiEndpoint + `/customer`;
  constructor(private http: HttpClient) {

  }

  getAllCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.baseUrl);
  }

  getCustomerByFilter(filter: Filter)  {
    return this.http.post(`${this.baseUrl}/filter`, filter);
  }

}
