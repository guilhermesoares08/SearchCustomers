import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { City } from '../_models/City';
import { Customer } from '../_models/Customer';
import { Filter } from '../_models/Filter';
import { Gender } from '../_models/Gender';
import { Region } from '../_models/Region';
import { UserSys } from '../_models/UserSys';

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

  getCustomerByUser(userId: number): Observable<Customer[]> {
    return this.http.get<Customer[]>(`${this.baseUrl}/getByUser/${userId}`);
  }

  getCustomerByFilter(filter: Filter)  {
    return this.http.post(`${this.baseUrl}/filter`, filter);
  }

  getAllCities(): Observable<City[]> {
    return this.http.get<City[]>(this.baseUrl + `/cities`);
  }

  getAllRegions(): Observable<Region[]> {
    return this.http.get<Region[]>(this.baseUrl + `/regions`);
  }

  getAllSellers(): Observable<UserSys[]> {
    return this.http.get<UserSys[]>(this.baseUrl + `/sellers`);
  }

  getAllGenders(): Observable<Gender[]> {
    return this.http.get<Gender[]>(this.baseUrl + `/genders`);
  }

}
