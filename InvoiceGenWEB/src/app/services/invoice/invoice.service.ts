import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InvoiceDto } from 'src/app/models/invoiceDto/invoice-dto';

import configurl from '../../../assets/config/config.json'; 

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  url = configurl.apiServer.url + '/api/InvoiceContents/';

  constructor(private http: HttpClient) { }

  CreateInvoice(invoice: InvoiceDto, auth_token: string): Observable<InvoiceDto> {
    const httpHeaders = { headers:new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
      }) 
    };
    return this.http.post<InvoiceDto>(this.url + 'SaveInvoiceContent', invoice, httpHeaders);
  }
}
