import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDto } from 'src/app/models/userdto/userdto';
import { UserEdit } from 'src/app/models/useredit/useredit';
import { Userm } from 'src/app/models/userm/userm';

import configurl from '../../../assets/config/config.json'; 

@Injectable({
  providedIn: 'root'
})

export class UserService {

  url = configurl.apiServer.url + '/api/Users/';

  constructor(private http: HttpClient) { }

  // Create
  CreateUser(userDto: UserDto): Observable<UserDto> {
    const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    return this.http.post<UserDto>(this.url + 'CreateUser', userDto, httpHeaders);
  }

  // Read
  GetUser(userId: number, auth_token: string): Observable<Userm> {
    const httpHeaders = { headers:new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
      }) 
    };
    return this.http.get<Userm>(this.url + 'GetUser/' +  userId, httpHeaders);
  }

  // Update
  UpdateUser(userId: number, userToEdit: UserEdit, auth_token: string): Observable<any> {
    const httpHeaders = { headers:new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
      }) 
    };
    return this.http.put<UserEdit>(this.url + 'UpdateUser/' +  userId, userToEdit, httpHeaders);
  }

  // Delete
  DeleteUser(userId: number, auth_token: string): Observable<any> {
    const httpHeaders = { headers:new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
      }) 
    };
    return this.http.delete(this.url + 'DeleteUser/' +  userId, httpHeaders);
  }
}
