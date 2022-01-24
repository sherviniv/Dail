import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationClient, UserDTO } from 'src/app/core/services/dail.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  model: UserDTO = {} as any;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    private client: AuthenticationClient,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
  }

  async registerFormSubmit(f: NgForm) {

    if (!f.valid ||
      (f.controls["password"].value &&
        f.controls["cpassword"].value !== f.controls["password"].value))
      return;

    this.spinner.show("main");
    debugger
    await this.client.register(this.model).toPromise().then(
      response => {
        this.toastr.success(`${this.model.firstName} عزیز ثبت نام شما با موفقیت انجام شد! لطفا وارد برنامه شوید`);
        this.spinner.hide("main");
        this.router.navigate(['authentication/login']);
      },
      error => {
        console.log(error);
        
        this.toastr.error("خطا هنگام ساخت کاربر");
      }
    );
    this.spinner.hide("main");

  }

}
