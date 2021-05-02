import { Component, OnInit } from '@angular/core';
import { Customer } from '../_models/Customer';
import { HttpClient } from '@angular/common/http';
import { CustomerService } from '../services/CustomerService.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  customers: Customer[];
  filteredCustomers: Customer[];
  constructor(private http: HttpClient, private customerService: CustomerService) {
    

   }

  ngOnInit() {
    this.getAllCustomers();
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
  
}
