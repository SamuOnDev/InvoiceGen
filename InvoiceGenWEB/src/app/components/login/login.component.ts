import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { NgForm } from '@angular/forms';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import configurl from '../../../assets/config/config.json'
import { UserLogin } from 'src/app/models/userlogin/userlogin';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html'
})
export class LoginComponent {

  invalidLogin?: boolean;
  responseLogin: any;

  url = configurl.apiServer.url + '/api/account/';

  constructor(private router: Router, private jwtHelper : JwtHelperService, private toastr: ToastrService, private authService: AuthService) { }


  Login(form: NgForm) {
    const userLogin: UserLogin = new UserLogin();
    userLogin.UserEmail = form.value.useremail;
    userLogin.UserPassword = form.value.userpassword;

    console.log(userLogin);

    this.authService.LoginUser(userLogin).subscribe({
      next: (response) => {
      this.responseLogin = response
      console.log(this.responseLogin);
      }, 
      error: (err: any) => {
        console.log(err.error)
        this.invalidLogin = true;
      },
      complete: () => {
        localStorage.setItem("jwt", this.responseLogin.token);
        localStorage.setItem("username", this.responseLogin.userName);
        localStorage.setItem("userid", this.responseLogin.userId);
        localStorage.setItem("userrole", this.responseLogin.userRole);
        this.invalidLogin = false;
        this.toastr.success('Login success');
      }
    });
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

}