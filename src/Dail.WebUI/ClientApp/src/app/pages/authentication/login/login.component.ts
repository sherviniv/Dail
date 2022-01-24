import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { LoginDTO } from 'src/app/core/services/dail.service';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  model: LoginDTO = { username: "", password: "" } as any;
  returnUrl: string = "";

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) {
    // redirect to home if already logged in
    if (this.authenticationService.currentUserValue.token) {
      this.router.navigate(['/panel']);
    }
  }

  ngOnInit(): void {
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  async loginFormSubmit(form: NgForm) {

    if (!form.valid) {
      return;
    }

    this.spinner.show("main");
    await this.authenticationService.login(this.model).then(response => {
      this.toastr.success("ورود شما با موفقیت انجام شد");
      this.router.navigate(['/panel']);
    }, (error) => this.toastr.error("خطا در ورود به برنامه"));
    this.spinner.hide("main");
  }

}
