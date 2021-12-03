import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-newCustomers',
  templateUrl: './newCustomers.component.html',
  styleUrls: ['./newCustomers.component.css']
})
export class NewCustomersComponent implements OnInit {

  public customers: any = [
    {
      Name: 'Guilherme',
      Id: 1
    },
    {
      Name: 'Gustavo',
      Id: 2
    },
    {
      Name: 'Sylvio',
      Id: 3
    },
    {
      Name: 'Lislaine',
      Id: 4
    },
    {
      Name: 'Carlos',
      Id: 5
    },
    {
      Name: 'Ederson',
      Id: 6
    }
  ];

  constructor() { }

  ngOnInit() {
  }

}
