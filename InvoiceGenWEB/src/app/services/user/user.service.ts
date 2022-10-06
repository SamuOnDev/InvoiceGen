import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDto } from 'src/app/models/userdto/userdto';
import { Userm } from 'src/app/models/userm/userm';

import configurl from '../../../assets/config/config.json'; 

@Injectable({
  providedIn: 'root'
})

export class UserService {

  url = configurl.apiServer.url + '/api/Users/';

  constructor(private http: HttpClient) { }

  // Create
  RegisterUser(userDto: UserDto): Observable<UserDto> {
    const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    return this.http.post<UserDto>(this.url + 'CreateUser', userDto, httpHeaders);
  }

  // Read
  GetUser(userId: number): Observable<Userm> {
    const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    return this.http.get<Userm>(this.url + 'GetUser/' +  userId, httpHeaders);
  }

  // Update

  // Delete

}
