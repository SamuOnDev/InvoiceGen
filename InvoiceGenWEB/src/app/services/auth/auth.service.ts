import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserLogin } from 'src/app/models/userlogin/userlogin';

import configurl from '../../../assets/config/config.json'; 

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  url = configurl.apiServer.url + '/api/Account/';

  constructor(private http: HttpClient) { }

  LoginUser(userLogin: UserLogin): Observable<any> {
    const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    return this.http.post<UserLogin>(this.url + 'AccountLogin', userLogin, httpHeaders);
  }
  
}
