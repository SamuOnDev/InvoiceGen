import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Userm } from 'src/app/models/userm/userm';

import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'userpanel',
  templateUrl: './userpanel.component.html',
  styleUrls: ['./userpanel.component.css']
})

export class UserpanelComponent implements OnInit {

  isEdit: boolean = false;
  userInfo: Userm = new Userm;
  
  constructor(private toastr: ToastrService, private userService: UserService) { }

  ngOnInit(): void {
    this.GetUserInfo();
  }

  NewPassword: string = '';
  ConfirmPassword: string = '';
  htmlStr: string = '';
  validated: any = null;

  check(){
    console.log(this.ConfirmPassword + " " + this.NewPassword + " " + this.validated)
    if (this.NewPassword == this.ConfirmPassword && this.NewPassword != '' && this.ConfirmPassword != '') {
      this.validated = true;
    } else {
      this.validated = false;
    }
  }

  IsEdit() {
    return this.isEdit;
  }

  EditUser() {
    const res = this.isEdit ? (this.isEdit = false, true) : (this.isEdit = true, false)    
  }

  SendUser() {
      
  }

  GetUserInfo() {
    const userId = Number(localStorage.getItem("userid"));

    this.userService.GetUser(userId).subscribe({
      next: (response) => {
        this.userInfo.userNickName = response.userNickName;
        this.userInfo.userName = response.userName;
        this.userInfo.userLast = response.userLast;
        this.userInfo.userEmail = response.userEmail;
        this.userInfo.userPhone = response.userPhone;      
      }, 
      error: (err: any) => {
        console.log(err.error)
      },
      complete: () => {
        this.toastr.success('Success');
      }
    });
  }

  // TODO: Terminar la logica para la edicion del usuario.

}
