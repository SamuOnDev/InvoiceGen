import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { InvoiceService } from 'src/app/services/invoice/invoice.service';
import { InvoiceContentService } from 'src/app/services/invoiceContent/invoice-content.service';
import { CompanyService } from 'src/app/services/company/company.service';
import { CompanyDto } from 'src/app/models/companyDto/company-dto';
import { InvoiceDto } from 'src/app/models/invoiceDto/invoice-dto';

@Component({
  selector: 'invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.css']
})
export class InvoicesComponent implements OnInit {

  invoices: any;
  invoiceProducts: any;
  invoiceCompany?: CompanyDto;
  invoice: any;
  isInvoiceDetails: boolean = true;
  isInvoiceToPdf: boolean = true;

  constructor(private invoiceService: InvoiceService, private toastr: ToastrService, private icontentService: InvoiceContentService, private companyService: CompanyService) { }

  ngOnInit(): void {
    this.GetInvoices();
  }

  IsInvoiceDetails() {
    return this.isInvoiceDetails;
  }

  IsConvertToPdf() {
    return this.isInvoiceToPdf;
  }

  InvoiceMenu(){
    this.isInvoiceDetails = false;
  }

  InvoiceDetails(invoiceId: number, companyId: number, invoice: InvoiceDto){
    this.isInvoiceDetails = true;
    this.GetInvoiceContentById(invoiceId);
    this.GetCompanyById(companyId);
    this.invoice = invoice;
    console.log(this.invoice);
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

  GetInvoiceContentById(invoiceId: number) {
    const userToken = localStorage.getItem("jwt") as string;
    
    this.icontentService.GetInvoiceContentById(invoiceId, userToken).subscribe({
      next: (response) => {
        this.invoiceProducts = response;
      }, 
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error("Error getting Invoices")
      },
      complete: () => {}
    });
  }

  GetCompanyById(companyId: number) {
    const userToken = localStorage.getItem("jwt") as string;
    
    this.companyService.GetCompanyById(companyId, userToken).subscribe({
      next: (response) => {
        this.invoiceCompany = response;
      }, 
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error("Error getting Invoices")
      },
      complete: () => {}
    });
  }


}
