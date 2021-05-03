import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserSys } from '../_models/UserSys';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  baseUrl = environment.apiEndpoint + `/authentication`;  

  constructor(private http: HttpClient) { }

  login(model: UserSys) {
    
    // return this.http.post(`${this.baseUrl}/login`, model).pipe(
    //     map((response: any) => {
    //       const user = response;
    //       if (user) {
    //         sessionStorage.setItem('login', user.login);
    //       }
    //     })
    //   );

    return this.http.post(`${this.baseUrl}/login`, model);
  }

  loggedIn() {
    var user = sessionStorage.getItem('login');
    return user != null;
  } 

  getUserByLogin(login: string): Observable<UserSys> {
    return this.http.get<UserSys>(`${this.baseUrl}/UserByLogin/${login}`);
  }

}
