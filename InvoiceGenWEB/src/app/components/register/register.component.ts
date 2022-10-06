import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/services/user/user.service';
import { UserDto } from 'src/app/models/userdto/userdto';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private router: Router, private userService: UserService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  password: string = '';
  confirm_password: string = '';
  myStyles = { color: 'red' };
  htmlStr: string = '';
  validated: boolean = false;

  check(){
    if (this.password == this.confirm_password && this.password != '') {
      this.myStyles.color = 'green';
      this.htmlStr = ' Matching';
      this.validated = true;
    } else {
      this.myStyles.color = 'red';
      this.htmlStr = ' Not Matching';
      this.validated = false;
    }
  }

  RegisterAccount(form: NgForm) {
    const userDto: UserDto = new UserDto();
    userDto.UserNickName = form.value.nickname;
    userDto.UserName = form.value.username;
    userDto.UserLast = form.value.lastname;
    userDto.UserEmail = form.value.useremail;
    userDto.UserPhone = form.value.userphone;
    userDto.UserPassword = form.value.userpassword;

    this.userService.RegisterUser(userDto).subscribe({
      complete: () => {
        form.reset();
        this.toastr.success(userDto.UserName + ' account created successfully');
      }, 
      error: (err: any) => {
        console.log(err.error)
        this.toastr.error(err.error)
      }
    });
  }
}
