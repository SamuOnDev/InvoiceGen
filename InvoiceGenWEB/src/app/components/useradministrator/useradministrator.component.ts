import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/services/admin/admin.service';

@Component({
  selector: 'useradministrator',
  templateUrl: './useradministrator.component.html',
  styleUrls: ['./useradministrator.component.css']
})
export class UseradministratorComponent implements OnInit {

  users: any;

  constructor(private adminService: AdminService, private toastr: ToastrService ) { }

  ngOnInit(): void {
    this.GetUsers()
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
      complete: () => {
        this.toastr.success('User updated succesfully');
      }
    });
  }

}
