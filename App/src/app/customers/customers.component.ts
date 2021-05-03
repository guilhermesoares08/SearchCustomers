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
import { AuthenticationService } from 'src/app/services/Authentication.service';
import { toArray } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  currentUser: UserSys;
  isUserAdmin: boolean;
  customers: Customer[];
  cities: City[];
  classifications: Classification[];
  genders: Gender[];
  regions: Region[];
  filteredRegions: Region[];
  sellers: UserSys[];
  filterForm: FormGroup;
  startDate: Date;
  endDate: Date;
  filteredCustomers: Customer[];
  filter: Filter;
  datepickerConfig: Partial<BsDatepickerConfig>;
  filteredCity: City;



  constructor(private http: HttpClient, private customerService: CustomerService, private formBuilder: FormBuilder, private authService: AuthenticationService, private toastr: ToastrService, public router: Router) {

    this.datepickerConfig = Object.assign({}, { dateInputFormat: 'DD/MM/YYYY' });

  }

  ngOnInit() {
    if (this.authService.loggedIn()) {
      this.isUserAdmin = this.currentUserIsAdmin();
      this.getCurrentUser();
      this.getAllCustomers();
      this.getAllCities();
      this.getAllRegions();
      this.getAllSellers();
      this.getAllClassification();
      this.getAllGenders();
    }

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
    if (this.authService.loggedIn()) {
      this.authService.getUserByLogin(localStorage.getItem('login')).subscribe(
        (_user: UserSys) => {
          this.currentUser = _user;
          if (this.currentUser != null) {
            this.customerService.getCustomerByUser(this.currentUser.id).subscribe(
              (_customers: Customer[]) => {
                this.customers = _customers;
                this.filteredCustomers = this.customers;
              }
            );
          }
        }
      );
    }

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
        this.filteredRegions = _regions;
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
    if (this.authService.loggedIn()) {
      this.filter = new Filter();
      this.filter.cityId = this.filterForm.controls['cityId'].value;
      this.filter.classificationId = this.filterForm.controls['classificationId'].value;
      this.filter.genderId = this.filterForm.controls['genderId'].value;
      this.filter.name = this.filterForm.controls['searchText'].value;
      this.filter.regionId = this.filterForm.controls['regionId'].value;
      this.filter.sellerId = this.filterForm.controls['sellerId'].value;
      this.filter.startDate = this.filterForm.controls['stDate'].value;
      this.filter.endDate = this.filterForm.controls['edDate'].value;
      this.filter.userId = this.currentUser.id;
      this.customerService.getCustomerByFilter(this.filter).subscribe(
        (responseCustomers: Customer[]) => {
          this.filteredCustomers = responseCustomers;
        }
      );
    }
  }
  onCitySelected() {
    this.customerService.getCityById(this.filterForm.value.cityId).subscribe(
      (_city: City) => {
        this.filteredCity = _city;
        this.filteredRegions = [];
        this.filteredRegions.push(_city.region);
      }
    );
  }

  getCurrentUser() {
    this.authService.getUserByLogin(localStorage.getItem('login')).subscribe(
      (_user: UserSys) => {
        this.currentUser = _user;
      }
    );
  }

  currentUserIsAdmin() {
    this.authService.getUserByLogin(localStorage.getItem('login')).subscribe(
      (_user: UserSys) => {
        this.currentUser = _user;
        this.isUserAdmin = _user.userRole.isAdmin;
        return _user.userRole.isAdmin;
      }
    );
    return false;
  }

  clearFormFields() {
    this.filteredRegions = this.regions;
    this.filterForm.reset();
  }  
}
