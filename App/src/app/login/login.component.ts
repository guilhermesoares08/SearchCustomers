import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from 'src/app/services/Authentication.service';
import { Md5 } from 'ts-md5';
import { UserSys } from '../_models/UserSys';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  title = 'Login';
  model: UserSys = { id: null, password: '', email: '', login: '', userRole: null };
  validUser: boolean;

  constructor(private authService: AuthenticationService
    ,         public router: Router
    ,         private toastr: ToastrService) {
      
      
     }

  ngOnInit() {   
    this.validUser = false;
    if (sessionStorage.getItem('login') != null) {
      this.router.navigate(['']);
    }
  }

  login() {    
    
    var tmpModel = Object.assign({}, this.model);
    tmpModel.password = this.encrypt(this.model.password);
    this.authService.login(tmpModel)
      .subscribe(
        (_return: any) => {          
          this.validUser = true;
          sessionStorage.setItem('login', _return.user.login);
          this.router.navigate(['']);
          this.toastr.success('Login Succefull');
        },
        error => {
          this.validUser = false;
          this.toastr.error('The email and/or password entered is invalid. Please try again.');
        }
      );
  }

  encrypt(text: string){
    const md5 = new Md5();
    return md5.appendStr(text).end() as string;    
  }

}
