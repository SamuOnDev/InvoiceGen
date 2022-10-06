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

  RegisterPage: boolean = false;
  UserPanel: boolean = false;

  isRegister() {
    return this.RegisterPage;
  }

  isUserPanel(){
    return this.UserPanel;
  }

  registerPage() {
    const res = this.RegisterPage ? (this.RegisterPage = false, true) : (this.RegisterPage = true, false)    
  }

  homePanel(){
    this.UserPanel = false;
  }

  userPanel() {
    const res = this.UserPanel = true;
  }

  isUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }

  isUserAdmin() {
    const role = Number(localStorage.getItem("userrole"));
    if (role == 1) {
      return true;
    }
    else {
      return false;
    }
  }

  public logOut = () => {
    localStorage.removeItem("jwt");
    localStorage.removeItem("username");
    localStorage.removeItem("userid");
    localStorage.removeItem("userrole")
  }
}