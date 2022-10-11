import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CompanyDto } from 'src/app/models/companyDto/company-dto';
import { InvoiceContent } from 'src/app/models/invoiceContent/invoice-content';
import { CompanyService } from 'src/app/services/company/company.service';

@Component({
  selector: 'invoice-creation',
  templateUrl: './invoice-creation.component.html',
  styleUrls: ['./invoice-creation.component.css']
})
export class InvoiceCreationComponent implements OnInit {

  companies: any;
  companyInfo: CompanyDto = new CompanyDto();
  chosenCompany: string = "0";
  dateNow?: string;
  isAddProduct: boolean = false;
  invoiceProducts: Array<InvoiceContent> = [];

  constructor(private companyService: CompanyService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.GetCompanies();
    this.dateNow = formatDate(new Date(), 'HH:mm - dd/MM/yyyy', 'en');
  }

  IsAddProductLine() {
    return this.isAddProduct;
  }

  AddProductLine() {
    this.isAddProduct ? (this.isAddProduct = false, true) : (this.isAddProduct = true, false);    
  }

  GetCompanies(){
    const userToken = localStorage.getItem("jwt") as string;

    this.companyService.GetCompanies(userToken).subscribe({
      next: (response) => {
        this.companies = response;
        console.log(this.companies);
      }, 
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error("Error getting companies")
      },
      complete: () => {}
    });
  }

  GetCompanyById(companyId: number){
    const userToken = localStorage.getItem("jwt") as string;

    this.companyService.GetCompanyById(companyId, userToken).subscribe({
      next: (response) => {
        this.companyInfo = response;
        
      }, 
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error("Error company get")
      },
      complete: () => {}
    });
  }

  CompanySelection(){
    if (this.chosenCompany != "0"){
      this.GetCompanyById(Number(this.chosenCompany));
      console.log(this.chosenCompany);
    }    
  }

  productToAdd: InvoiceContent = {};
  totalArticles: number = 0;
  totalPrice: number = 0;

  AddProduct() {

    const product = new InvoiceContent();
    product.IContentArticleNumber = this.invoiceProducts.length+1 || 0;
    product.IContentDescription = this.productToAdd.IContentDescription;
    product.IContentQuantity = this.productToAdd.IContentQuantity || 0;
    product.IContentUnitPrice = this.productToAdd.IContentUnitPrice || 0;
    product.IContentDiscount = Number(this.productToAdd.IContentDiscount) || 0;

    if (product.IContentDiscount != 0){
      product.IContentPrice = Number((((100-product.IContentDiscount)*product.IContentUnitPrice/100.0) * product.IContentQuantity).toFixed(2));     
    }else{
      product.IContentPrice = product.IContentQuantity*product.IContentUnitPrice;
    }

    

    this.invoiceProducts.push(product);

    this.RefreshQuantityPrice();
  }
  
  DeleteProduct(ArticleNumber: number) {

    if(ArticleNumber == 0){
      this.toastr.error("No product to delete")
    }

    let indexOfProduct = this.invoiceProducts.findIndex(x => x.IContentArticleNumber === ArticleNumber);
    
    if (indexOfProduct !== -1) {
      this.invoiceProducts.splice(indexOfProduct, 1);
    }    

    this.RefreshQuantityPrice();
  }

  RefreshQuantityPrice(){
    this.totalArticles = 0;
    this.totalPrice = 0;

    this.invoiceProducts.forEach(element => {
      this.totalArticles = this.totalArticles + Number(element.IContentQuantity);
      this.totalPrice = this.totalPrice + Number(element.IContentPrice);
    });
  }

}
