import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})

export class HomepageComponent  {

  constructor(private jwtHelper: JwtHelperService, private router: Router) {
  }

  registerPage: boolean = false;
  companiesPanel: boolean = false;
  invoicesPanel: boolean = false;
  adminPanel: boolean = false;
  userPanel: boolean = false;
  createInvoicePanel: boolean = false;
  

  IsRegister() {
    return this.registerPage;
  }
  
  IsCompaniesPanel(){
    return this.companiesPanel;
  }

  IsInvoicesPanel(){
    return this.invoicesPanel;
  }
  
  IsAdminPanel(){
    return this.adminPanel;
  }

  IsUserPanel(){
    return this.userPanel;
  }

  IsCreateInvoicePanel(){
    return this.createInvoicePanel;
  }

  RegisterPage() {
    const res = this.registerPage ? (this.registerPage = false, true) : (this.registerPage = true, false)    
  }

  HomePanel(){
    this.companiesPanel = false;
    this.invoicesPanel = false;
    this.adminPanel = false;
    this.userPanel = false;
    this.createInvoicePanel = false;
  }

  CompaniesPanel(){
    this.companiesPanel = true;
    this.invoicesPanel = false;
    this.adminPanel = false;
    this.userPanel = false;
    this.createInvoicePanel = false;
  }

  public InvoicesPanel() {
    console.log("holaaaaaaaaaaaaaaa")
    this.companiesPanel = false;
    this.invoicesPanel = true;
    this.adminPanel = false;
    this.userPanel = false;
    this.createInvoicePanel = false;
    console.log(this.invoicesPanel)
  }

  AdminPanel(){
    this.companiesPanel = false;
    this.invoicesPanel = false;
    this.adminPanel = true;
    this.userPanel = false;
    this.createInvoicePanel = false;
  }

  UserPanel() {
    this.companiesPanel = false;
    this.invoicesPanel = false;
    this.adminPanel = false;
    this.userPanel = true;
    this.createInvoicePanel = false;
  }

  CreateInvoicePanel() {
    this.companiesPanel = false;
    this.invoicesPanel = false;
    this.adminPanel = false;
    this.userPanel = false;
    this.createInvoicePanel = true;
  }
    
  IsUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }

  IsUserAdmin() {
    const role = Number(localStorage.getItem("userrole"));
    if (role == 1) {
      return true;
    }
    else {
      return false;
    }
  }

  public LogOut = () => {
    localStorage.removeItem("jwt");
    localStorage.removeItem("username");
    localStorage.removeItem("userid");
    localStorage.removeItem("userrole")
  }
}