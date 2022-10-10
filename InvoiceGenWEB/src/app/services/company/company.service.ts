import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from 'src/app/models/company/company';
import { CompanyDto } from 'src/app/models/companyDto/company-dto';

import configurl from '../../../assets/config/config.json'; 

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  url = configurl.apiServer.url + '/api/Companies/';

  constructor(private http: HttpClient) { }

  CreateCompany(company: Company, auth_token: string): Observable<Company> {
    const httpHeaders = { headers:new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
      }) 
    };
    return this.http.post<Company>(this.url + 'CreateCompany', company, httpHeaders);
  }

  GetCompanies(auth_token: string): Observable<CompanyDto> {
    const httpHeaders = { headers:new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
      }) 
    };
    return this.http.get<CompanyDto>(this.url + 'GetCompanies/', httpHeaders);
  }
}
