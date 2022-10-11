import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.css']
})
export class InvoicesComponent implements OnInit {

  isInvoice: boolean = false;
  isCreateInvoice: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  IsInvoice() {
    return this.isInvoice;
  }
  
  IsCreateInvoice() {
    return this.isCreateInvoice;
  }

}
