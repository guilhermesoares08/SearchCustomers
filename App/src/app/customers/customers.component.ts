import { Component, OnInit } from '@angular/core';
import { Customer } from '../_models/Customer';
import { HttpClient } from '@angular/common/http';
import { CustomerService } from '../services/CustomerService.service';
import { Classification } from '../_models/Classification';
import { Gender } from '../_models/Gender';
import { Region } from '../_models/Region';
import { City } from '../_models/City';

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
  startDate: Date;
  endDate: Date;
  filteredCustomers: Customer[];
  constructor(private http: HttpClient, private customerService: CustomerService) {
    

   }

  ngOnInit() {
    this.getAllCustomers();
    this.getAllCities();
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

  getAllCities()  {
    this.customerService.getAllCities().subscribe(
      (_cities: City[])=>{
        this.cities = _cities;
      }
    );
  }
  
}
