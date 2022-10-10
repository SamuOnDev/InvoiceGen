import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Company } from 'src/app/models/company/company';
import { CompanyService } from 'src/app/services/company/company.service';

@Component({
  selector: 'companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent implements OnInit {

  isCompanyInfo: boolean = false;
  isCreateCompany: boolean = false;
  isEdit: boolean = false;
  companies: any;

  constructor(private companyService: CompanyService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.GetCompanies();
  }

  IsEdit() {
    return this.isEdit;
  }
  
  IsCompany() {
    return this.isCompanyInfo;
  }

  IsCreateCompany() {
    return this.isCreateCompany;
  }

  CompanyList(){
    this.isCompanyInfo = false;
    this.isCreateCompany = false;
  }

  CompanyPanel(){
    this.isCompanyInfo = true;
  }

  CreateCompanyPanel(){
    this.isCreateCompany = true;
  }

  EditUser() {
    const res = this.isEdit ? (this.isEdit = false, true) : (this.isEdit = true, false)    
  }

  RegisterNewCompany(registerCompanyForm: NgForm){
    const userToken = localStorage.getItem("jwt") as string;

    const company: Company = new Company();
    company.CompanyName = registerCompanyForm.value.companyName;
    company.CompanyCif = registerCompanyForm.value.companyCif;
    company.CompanyEmail = registerCompanyForm.value.companyEmail;   
    company.CompanyPhone = registerCompanyForm.value.companyPhone;
    company.CompanyAddress = registerCompanyForm.value.companyAddress;     

    console.log(company);

    this.companyService.CreateCompany(company, userToken).subscribe({
      complete: () => {
        this.isCreateCompany = false;
        this.toastr.success('Company created successfully');
      }, 
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error(err.error)
      }
    });
  }

  GetCompanies(){
    const userToken = localStorage.getItem("jwt") as string;

    this.companyService.GetCompanies(userToken).subscribe({
      next: (response) => {
        this.companies = response;
      }, 
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error("Error getting companies")
      },
      complete: () => {}
    });
  }
}
