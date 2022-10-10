import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Userm } from 'src/app/models/userm/userm';

import configurl from '../../../assets/config/config.json'; 

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  url = configurl.apiServer.url + '/api/Administrator/';

  constructor(private http: HttpClient) { }

  GetUsers(auth_token: string): Observable<Userm> {
    const httpHeaders = { headers:new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
      }) 
    };
    return this.http.get<Userm>(this.url + 'GetUsers/', httpHeaders);
  }
}
