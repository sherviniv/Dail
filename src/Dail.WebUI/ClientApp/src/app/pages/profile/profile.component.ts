import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationClient, UserDTO } from 'src/app/core/services/dail.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  model: UserDTO = {} as any;

  constructor(
    private router: Router,
    private client: AuthenticationClient,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.loadUserInfo();
  }

  async loadUserInfo() {
    this.spinner.show('main');
    await this.client.getUserInfo().toPromise().then(
      response => {
        this.model = response;
      },
      error =>
        this.toastr.error("خطا در دریافت اطلاعات کاربر")
    );
    this.spinner.hide('main')
  }

  async onsubmit(f: NgForm) {

    (f.controls["password"].value &&
      f.controls["cpassword"].value !== f.controls["password"].value)

    this.spinner.show('main');
    await this.client.updateProfile(this.model).toPromise().then(
      response => {
        this.toastr.success("اطلاعات با موفقیت ثبت شد");
        this.router.navigate(['/panel']);
      },
      error =>
        this.toastr.error("خطا در ثبت اطلاعات")
    );
    this.spinner.hide('main');
  }

}
