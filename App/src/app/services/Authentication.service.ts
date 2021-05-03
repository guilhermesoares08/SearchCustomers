import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  baseUrl = environment.apiEndpoint + `/authentication`;  

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(`${this.baseUrl}/login`, model).pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            sessionStorage.setItem('login', user.login);
          }
        })
      );
  }

  loggedIn() {
    var user = sessionStorage.getItem('login');
    return user != null;
  }

  

}
