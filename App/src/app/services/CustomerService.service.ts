import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { City } from '../_models/City';
import { Classification } from '../_models/Classification';
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

  getAllCustomers() {
    return this.http.get<Customer[]>(this.baseUrl);
  }

  getCustomerByUser(userId: number) {
    return this.http.get<Customer[]>(`${this.baseUrl}/getByUser/${userId}`);
  }

  getCustomerByFilter(filter: Filter)  {
    return this.http.post(`${this.baseUrl}/filter`, filter);
  }

  getAllCities(){
    return this.http.get<City[]>(this.baseUrl + `/cities`);
  }

  getAllRegions() {
    return this.http.get<Region[]>(this.baseUrl + `/regions`);
  }

  getAllSellers(){
    return this.http.get<UserSys[]>(this.baseUrl + `/sellers`);
  }

  getAllGenders() {
    return this.http.get<Gender[]>(this.baseUrl + `/genders`);
  }

  getAllClassifications() {
    return this.http.get<Classification[]>(this.baseUrl + `/classifications`);
  }

  getCityById(id: number) {
    return this.http.get<City>(`${this.baseUrl}/cities/${id}`);
  }

}
