import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserSys } from '../_models/UserSys';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  baseUrl = environment.apiEndpoint + `/authentication`;  

  constructor(private http: HttpClient) { }

  login(model: UserSys) {
    return this.http.post(`${this.baseUrl}/login`, model);
  }

  loggedIn() {
    var user = localStorage.getItem('login');
    return user != null;
  } 

  getUserByLogin(login: string) {
    return this.http.get<UserSys>(`${this.baseUrl}/UserByLogin/${login}`);
  }

}
