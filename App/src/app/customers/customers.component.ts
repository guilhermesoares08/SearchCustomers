import { Component, OnInit } from '@angular/core';
import { Customer } from '../_models/Customer';
import { HttpClient } from '@angular/common/http';
import { CustomerService } from '../services/CustomerService.service';
import { Classification } from '../_models/Classification';
import { Gender } from '../_models/Gender';
import { Region } from '../_models/Region';
import { City } from '../_models/City';
import { UserSys } from '../_models/UserSys';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Filter } from '../_models/Filter';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';

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
  filterForm: FormGroup;
  startDate: Date;
  endDate: Date;
  filteredCustomers: Customer[];
  filter: Filter;
  datepickerConfig: Partial<BsDatepickerConfig>;
  constructor(private http: HttpClient, private customerService: CustomerService, private formBuilder: FormBuilder) {
    this.datepickerConfig = Object.assign({}, { dateInputFormat: 'DD/MM/YYYY' });

  }

  ngOnInit() {
    this.getAllCustomers();
    this.getAllCities();
    this.getAllRegions();
    this.getAllSellers();
    this.getAllClassification();
    this.getAllGenders();

    this.filterForm = new FormGroup({
      cityId: new FormControl(null),
      regionId: new FormControl(null),
      sellerId: new FormControl(null),
      classificationId: new FormControl(null),
      stDate: new FormControl(null),
      edDate: new FormControl(null),
      genderId: new FormControl(null),
      searchText: new FormControl(null)
    });
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

  searchCustomer() {
    this.filter = new Filter();
    this.filter.cityId = this.filterForm.controls['cityId'].value;
    this.filter.classificationId = this.filterForm.controls['classificationId'].value;
    this.filter.genderId = this.filterForm.controls['genderId'].value;
    this.filter.name = this.filterForm.controls['searchText'].value;
    this.filter.regionId = this.filterForm.controls['regionId'].value;
    this.filter.sellerId = this.filterForm.controls['sellerId'].value;
    this.filter.startDate = this.filterForm.controls['stDate'].value;
    this.filter.endDate = this.filterForm.controls['edDate'].value;

    this.customerService.getCustomerByFilter(this.filter).subscribe(
      (responseCustomers: Customer[]) => {
        this.filteredCustomers = responseCustomers;
      }
    );
  }

  // logout() {
  //   localStorage.removeItem('token');
  //   this.toastr.show('Log Out');
  //   this.router.navigate(['/user/login']);
  // }

}
