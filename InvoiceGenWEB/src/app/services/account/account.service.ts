import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDto } from 'src/app/models/userdto/userdto';

import configurl from '../../../assets/config/config.json'; 

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  url = configurl.apiServer.url + '/api/Account/';

  constructor(private http: HttpClient) { }

  RegisterUser(userDto: UserDto): Observable<UserDto> {
    const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    return this.http.post<UserDto>(this.url + 'AccountCreate', userDto, httpHeaders);
  }
  
}
