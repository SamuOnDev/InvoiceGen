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

  isRegisterPage: boolean = false;

  isRegister() {
    if (this.isRegisterPage) {
      return true;
    }
    else {
      return false;
    }
  }

  registerPage(itIs: boolean) {
    this.isRegisterPage = itIs;
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

  public logOut = () => {
    localStorage.removeItem("jwt");
    localStorage.removeItem("username");
    localStorage.removeItem("userid");
  }
}