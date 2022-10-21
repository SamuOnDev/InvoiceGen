import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CompanyDto } from 'src/app/models/companyDto/company-dto';
import { UserEdit } from 'src/app/models/useredit/useredit';
import { Userm } from 'src/app/models/userm/userm';
import { AdminService } from 'src/app/services/admin/admin.service';
import { UserService } from 'src/app/services/user/user.service';
import { CompanyService } from 'src/app/services/company/company.service';
import { NgForm } from '@angular/forms';
import { CompanyEdit } from 'src/app/models/companyEdit/company-edit';

@Component({
  selector: 'useradministrator',
  templateUrl: './useradministrator.component.html',
  styleUrls: ['./useradministrator.component.css']
})
export class UseradministratorComponent implements OnInit {

  users: any;
  userIdDetail: number = 0;
  isEdit: boolean = false;
  isUserDetails: boolean = false;
  userInfo: Userm = new Userm;
  ConfirmPassword: string = '';
  OldPassword: string = '';
  myStyles = {'color': 'red', 'font-size': '12px', 'font-weight': 'bold'};
  htmlStr: string = '';
  validated: any = null;
  needPassword: any = true;
  isCompanyInfo: boolean = false;
  companies: any;
  companyInfo: CompanyDto = new CompanyDto();
  isCompaniesDetails: boolean = false;

  constructor(private adminService: AdminService, private toastr: ToastrService, private userService: UserService, private companyService: CompanyService ) { }

  ngOnInit(): void {
    this.GetUsers();
  }

  IsEdit() {
    return this.isEdit;
  }

  IsUserDetails() {
    return this.isUserDetails;
  }

  IsCompaniesDetails() {
    return this.isCompaniesDetails;
  }
  IsCompany() {
    return this.isCompanyInfo;
  }

  EditUser() {
    this.isEdit ? (this.isEdit = false, true) : (this.isEdit = true, false)    
  }

  UserDetails() {
    this.isUserDetails ? (this.isUserDetails = false, true) : (this.isUserDetails = true, false)    
  }

  GoToCompaniesByUser(userId: number){
    this.userIdDetail = userId;
    this.isCompaniesDetails = true;
    this.CompanyList();
  }

  CompanyList(){
    this.isCompanyInfo = false;
    this.GetCompanies();
  }
  
  CompanyPanel(companyId: number){
    this.isCompanyInfo ? (this.isCompanyInfo = false, true) : (this.isCompanyInfo = true, false)

    if (this.isCompanyInfo == true) {
      this.GetCompanyById(companyId)
    }
  }

  EditCompany() {
    this.isEdit ? (this.isEdit = false, true) : (this.isEdit = true, false)    
  }

  GetUsers(){
    const userToken = localStorage.getItem("jwt") as string;
    this.adminService.GetUsers(userToken).subscribe({
      next: (response) => {
        this.users = response;
        console.log(this.users)
      }, 
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error("Error getting users")
      },
      complete: () => {}
    });
  }

  GoToUserDetails(userId: number) {
    this.UserDetails();
    this.userIdDetail = userId;
    const userToken = localStorage.getItem("jwt") as string;

    this.userService.GetUser(userId, userToken).subscribe({
      next: (response) => {
        this.userInfo.userNickName = response.userNickName;
        this.userInfo.userName = response.userName;
        this.userInfo.userLast = response.userLast;
        this.userInfo.userEmail = response.userEmail;
        this.userInfo.userPhone = response.userPhone;      
      }, 
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error("Get user info error")
      },
      complete: () => {}
    });
  }

  SendUser() {
    const userToken = localStorage.getItem("jwt") as string;

    const userToEdit: UserEdit = new UserEdit();
    userToEdit.UserNickName = this.userInfo.userNickName;
    userToEdit.UserName = this.userInfo.userName;
    userToEdit.UserLast = this.userInfo.userLast;
    userToEdit.UserPhone = this.userInfo.userPhone;
    userToEdit.UserNewPassword = this.userInfo.userPassword;
    userToEdit.UserEmail = this.userInfo.userEmail;
    console.log(userToEdit); 

    this.userService.UpdateUser(this.userIdDetail, userToEdit, userToken).subscribe({
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error("Error al editar el usuario")
      },
      complete: () => {
        this.toastr.success('User updated succesfully');
        this.userInfo.userPassword = '';
        this.ConfirmPassword = '';
        this.validated = null;
        this.needPassword = true;
        this.UserDetails();
        this.GetUsers();
      }
    });
  }

  DeleteUser() {
    const userToken = localStorage.getItem("jwt") as string;

    if (confirm('Do you want to delete your account?')) {
      this.userService.DeleteUser(this.userIdDetail, userToken).subscribe({
        error: (err: any) => {
          console.log(err.error)
          this.toastr.error(err.error);
        },
        complete: () => {
          this.toastr.success('User Deleted Successfully');
          this.UserDetails();
          this.GetUsers();
        }
      });
    }
  }

  Check(){
    if (this.userInfo.userPassword == this.ConfirmPassword && this.userInfo.userPassword != '' && this.ConfirmPassword != '') {
      this.validated = true;
      this.myStyles = {'color': 'green', 'font-size': '12px', 'font-weight': 'bold'};
      this.htmlStr = ' Matching';
    } else {
      this.validated = false;
      this.myStyles = {'color': 'red', 'font-size': '12px', 'font-weight': 'bold'};
      this.htmlStr = ' Not Matching';
    }
  }

  NeedPassword(){
    console.log(this.htmlStr);
    if (this.userInfo.userPassword == '' || this.ConfirmPassword == '' || this.htmlStr == " Not Matching"){
      this.needPassword = false;
    }else{
      this.needPassword = true;
    }
  }

  GetCompanies(){
    const userToken = localStorage.getItem("jwt") as string;

    this.companyService.GetCompanies(this.userIdDetail, userToken).subscribe({
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
          this.EditCompany();
          this.toastr.success('Company Deleted Successfully');
        }
      });
    }
  }

}
