import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InvoiceContent } from 'src/app/models/invoiceContent/invoice-content';

import configurl from '../../../assets/config/config.json'; 

@Injectable({
  providedIn: 'root'
})
export class InvoiceContentService {

  url = configurl.apiServer.url + '/api/Invoice/';

  urlContent = configurl.apiServer.url + '/api/InvoiceContents/';

  constructor(private http: HttpClient) { }

  GetInvoiceContentById(invoiceId: number, auth_token: string): Observable<InvoiceContent> {
    const httpHeaders = { headers:new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
      }) 
    };
    return this.http.get<InvoiceContent>(this.urlContent + 'GetInvoiceContent/' + invoiceId, httpHeaders);
  }
}
