import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { InvoiceService } from 'src/app/services/invoice/invoice.service';
import { InvoiceContentService } from 'src/app/services/invoiceContent/invoice-content.service';
import { CompanyService } from 'src/app/services/company/company.service';
import { CompanyDto } from 'src/app/models/companyDto/company-dto';
import { InvoiceDto } from 'src/app/models/invoiceDto/invoice-dto';
import domtoimage from 'dom-to-image';
import  jsPDF from 'jspdf';

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
  isInvoiceDetails: boolean = false;
  isInvoiceToPdf: boolean = false;

  constructor(private invoiceService: InvoiceService, private toastr: ToastrService, private icontentService: InvoiceContentService, private companyService: CompanyService) { }

  ngOnInit(): void {
    this.GetInvoices();
  }

  @ViewChild('pdfInvoice')
  pdfInvoice!: ElementRef;

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

  ConvertToPdfPreview(){
    this.isInvoiceToPdf = true;
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

  public downloadAsPDF(title: string) {
    let div = this.pdfInvoice.nativeElement;

    var img: any;
    var filename;
    var newImage: any;

    domtoimage.toPng(div, { bgcolor: '#fff' })
    .then(function (dataUrl) {
      img = new Image();
      img.src = dataUrl;
      newImage = img.src;
      img.onload = function () {
        var pdfWidth = img.width;
        var pdfHeight = img.height;
        var doc;
        doc = new jsPDF('p', 'px', [pdfWidth, pdfHeight]);

        var width = doc.internal.pageSize.getWidth();
        var height = doc.internal.pageSize.getHeight();

        doc.addImage(newImage, 'PNG', 10, 10, width, height);
        filename = 'Invoice_' + title + '.pdf';
        doc.save(filename);
      };
    })
    .catch((error) => {
      this.toastr.error("Error generating PDF")
    });
  }

}
