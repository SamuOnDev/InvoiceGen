import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Company } from 'src/app/models/company/company';
import { CompanyDto } from 'src/app/models/companyDto/company-dto';
import { CompanyEdit } from 'src/app/models/companyEdit/company-edit';
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
  companyInfo: CompanyDto = new CompanyDto();

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

  CompanyPanel(companyId: number){
    this.isCompanyInfo = true;
    this.GetCompanyById(companyId)
  }

  CreateCompanyPanel(){
    this.isCreateCompany = true;
  }

  EditCompany() {
    this.isEdit ? (this.isEdit = false, true) : (this.isEdit = true, false)    
  }

  RegisterNewCompany(registerCompanyForm: NgForm){
    const userToken = localStorage.getItem("jwt") as string;

    const company: Company = new Company();
    company.CompanyName = registerCompanyForm.value.companyName;
    company.CompanyCif = registerCompanyForm.value.companyCif;
    company.CompanyEmail = registerCompanyForm.value.companyEmail;   
    company.CompanyPhone = registerCompanyForm.value.companyPhone;
    company.CompanyAddress = registerCompanyForm.value.companyAddress;     

    this.companyService.CreateCompany(company, userToken).subscribe({
      complete: () => {
        this.isCreateCompany = false;
        this.GetCompanies();
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

  UpdateCompanyById(updateCompanyForm: NgForm){
    const userToken = localStorage.getItem("jwt") as string;

    const companyUpdates: CompanyEdit = new CompanyEdit();
    companyUpdates.CompanyId = updateCompanyForm.value.companyId;
    companyUpdates.CompanyName = updateCompanyForm.value.companyName;
    companyUpdates.CompanyCif = updateCompanyForm.value.companyCif;
    companyUpdates.CompanyEmail = updateCompanyForm.value.companyEmail;   
    companyUpdates.CompanyPhone = updateCompanyForm.value.companyPhone;
    companyUpdates.CompanyAddress = updateCompanyForm.value.companyAddress;     

    this.companyService.UpdateCompanyById(companyUpdates, userToken).subscribe({
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error("Error updating company")
      },
      complete: () => {
        this.GetCompanies();
        this.isCompanyInfo = false;
        this.isCreateCompany = false;
        this.EditCompany();
        this.toastr.success('Company updated successfully');
      }
    });
  }

  DeleteCompany() {
    const userToken = localStorage.getItem("jwt") as string;

    if (confirm('Do you want to delete this company?')) {
      this.companyService.DeleteCompany(Number(this.companyInfo.companyId), userToken).subscribe({
        error: (err: any) => {
          console.log(err.error)
          this.toastr.error(err.error);
        },
        complete: () => {
          this.GetCompanies();
          this.isCompanyInfo = false;
          this.isCreateCompany = false;
          this.EditCompany();
          this.toastr.success('Company Deleted Successfully');
        }
      });
    }
  }
}
