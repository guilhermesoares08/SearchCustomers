import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from 'src/app/services/Authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  title = 'Login';
  model: any = {};

  constructor(private authService: AuthenticationService
    ,         public router: Router
    ,         private toastr: ToastrService) { }

  ngOnInit() {
    if (localStorage.getItem('login') != null) {
      this.router.navigate(['']);
    }
  }

  login() {
    this.authService.login(this.model)
      .subscribe(
        () => {
          this.router.navigate(['']);
          this.toastr.success('Login Succefull');
        },
        error => {
          this.toastr.error('the username of pass is incorrect');
        }
      );
  }

}
