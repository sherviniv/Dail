import { Component, OnInit } from '@angular/core';
import { Form } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { LoginDTO } from 'src/app/core/services/dail.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  model: LoginDTO = { username : "" , password : ""} as any;
  returnUrl: string = "";

  constructor(private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.spinner.show("main");
  }

  loginFormSubmit(form : Form){

  }

}
