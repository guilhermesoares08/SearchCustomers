import { Component, OnInit } from '@angular/core';
import { Customer } from '../_models/Customer';
import { HttpClient } from '@angular/common/http';
import { CustomerService } from '../services/CustomerService.service';
import { Classification } from '../_models/Classification';
import { Gender } from '../_models/Gender';
import { Region } from '../_models/Region';
import { City } from '../_models/City';
import { UserSys } from '../_models/UserSys';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  customers: Customer[];
  cities: City[];
  classifications: Classification[];
  genders: Gender[];
  regions: Region[];
  sellers: UserSys[];
  startDate: Date;
  endDate: Date;
  filteredCustomers: Customer[];
  constructor(private http: HttpClient, private customerService: CustomerService) {


  }

  ngOnInit() {
    this.getAllCustomers();
    this.getAllCities();
    this.getAllRegions();
    this.getAllSellers();
    this.getAllClassification();
    this.getAllGenders();
  }

  getAllCustomers() {
    this.customerService.getAllCustomers().subscribe(
      // tslint:disable-next-line: variable-name
      (_customers: Customer[]) => {
        this.customers = _customers;
        this.filteredCustomers = this.customers;
      }
    );
  }

  getAllCities() {
    this.customerService.getAllCities().subscribe(
      (_cities: City[]) => {
        this.cities = _cities;
      }
    );
  }

  getAllSellers() {
    this.customerService.getAllSellers().subscribe(
      (_sellers: UserSys[]) => {
        this.sellers = _sellers;
      }
    );
  }

  getAllRegions() {
    this.customerService.getAllRegions().subscribe(
      (_regions: Region[]) => {
        this.regions = _regions;
      }
    );
  }

  getAllGenders() {
    this.customerService.getAllGenders().subscribe(
      (_genders: Gender[]) => {
        this.genders = _genders;
      }
    );
  }

  getAllClassification() {
    this.customerService.getAllClassifications().subscribe(
      (_classifications: Classification[]) => {
        this.classifications = _classifications
      }
    );
  }

}
