import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Invoice } from 'src/app/models/invoice/invoice';
import { InvoiceService } from 'src/app/services/invoice/invoice.service';
import { InvoiceContentService } from 'src/app/services/invoiceContent/invoice-content.service';

@Component({
  selector: 'invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.css']
})
export class InvoicesComponent implements OnInit {

  invoices: any;
  invoiceProducts: any;
  isInvoiceDetails: boolean = false;

  constructor(private invoiceService: InvoiceService, private toastr: ToastrService, private icontentService: InvoiceContentService) { }

  ngOnInit(): void {
    this.GetInvoices();
  }

  IsInvoiceDetails() {
    return this.isInvoiceDetails;
  }

  InvoiceDetails(invoiceId: number){
    this.isInvoiceDetails = true;
    this.GetInvoiceContentById(invoiceId)
  }

  GetInvoices(){
    const userToken = localStorage.getItem("jwt") as string;

    this.invoiceService.GetInvoices(userToken).subscribe({
      next: (response) => {
        this.invoices = response;
      }, 
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error("Error getting Invoices")
      },
      complete: () => {}
    });
  }

  GetInvoiceContentById(invoiceId: number){
    const userToken = localStorage.getItem("jwt") as string;
    console.log(invoiceId)
    
    this.icontentService.GetInvoiceContentById(invoiceId, userToken).subscribe({
      next: (response) => {
        this.invoiceProducts = response;
        console.log(this.invoiceProducts)
      }, 
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error("Error getting Invoices")
      },
      complete: () => {}
    });
  }


}
