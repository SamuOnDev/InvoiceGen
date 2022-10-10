import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserEdit } from 'src/app/models/useredit/useredit';
import { Userm } from 'src/app/models/userm/userm';
import { HomepageComponent } from '../homepage/homepage.component';

import { UserService } from 'src/app/services/user/user.service';

@Component({
  providers: [HomepageComponent],
  selector: 'userpanel',
  templateUrl: './userpanel.component.html',
  styleUrls: ['./userpanel.component.css']
})

export class UserpanelComponent implements OnInit {

  isEdit: boolean = false;
  invalidLogin?: boolean;
  userInfo: Userm = new Userm;
  ConfirmPassword: string = '';
  OldPassword: string = '';
  myStyles = {'color': 'red', 'font-size': '12px', 'font-weight': 'bold'};
  htmlStr: string = '';
  validated: any = null;
  needPassword: any = null;

  constructor(private toastr: ToastrService, private userService: UserService, private homeComp: HomepageComponent) { }

  ngOnInit(): void {
    this.GetUserInfo();
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
    if (this.userInfo.userPassword != '' && this.ConfirmPassword != '' && this.OldPassword == ''){
      this.needPassword = false;
    }else if(this.userInfo.userPassword != '' && this.ConfirmPassword != '' && this.OldPassword != ''){
      this.needPassword = true;
    }else if(this.OldPassword != ''){
      this.needPassword = true;
    }
  }

  IsEdit() {
    return this.isEdit;
  }

  EditUser() {
    const res = this.isEdit ? (this.isEdit = false, true) : (this.isEdit = true, false)    
  }

  SendUser() {
    const userId = Number(localStorage.getItem("userid"));
    const userToken = localStorage.getItem("jwt") as string;

    const userToEdit: UserEdit = new UserEdit();
    userToEdit.UserNickName = this.userInfo.userNickName;
    userToEdit.UserName = this.userInfo.userName;
    userToEdit.UserLast = this.userInfo.userLast;
    userToEdit.UserPhone = this.userInfo.userPhone;
    userToEdit.UserPassword = this.OldPassword;
    userToEdit.UserNewPassword = this.userInfo.userPassword;
    userToEdit.UserEmail = this.userInfo.userEmail;
    console.log(userToEdit); 

    this.userService.UpdateUser(userId, userToEdit, userToken).subscribe({
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error("Error al editar el usuario")
        this.invalidLogin = true;
      },
      complete: () => {
        this.toastr.success('User updated succesfully');
        this.OldPassword = '';
        this.userInfo.userPassword = '';
        this.ConfirmPassword = '';
        this.validated = null;
        this.needPassword = null;
        this.GetUserInfo();
        this.EditUser();
        this.invalidLogin = false;
      }
    });
  }

  GetUserInfo() {
    const userId = Number(localStorage.getItem("userid"));
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

  DeleteUser() {
    const userId = Number(localStorage.getItem("userid"));
    const userToken = localStorage.getItem("jwt") as string;

    if (confirm('Do you want to delete your account?')) {
      this.userService.DeleteUser(userId, userToken).subscribe({
        error: (err: any) => {
          console.log(err.error)
          this.toastr.error(err.error);
        },
        complete: () => {
          this.toastr.success('User Deleted Successfully');
          this.homeComp.LogOut();
        }
      });
    }
  }
}
