import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from 'src/app/pages/authentication/services/authentication.service';
import { ConfirmDialogService } from '../confirm-dialog/confirm-dialog.service';

@Component({
  selector: 'dail-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private toastr: ToastrService,
    private confirm: ConfirmDialogService) { }

  ngOnInit(): void {
  }

  async logout() {
    let isConfirmed: boolean = await this.confirm.confirm("خروج از حساب کاربری؟"
    , "برای خروج بر بروی خروج کلیک کنید", "خروج", "لغو", "md");
    if (isConfirmed) {
      this.authenticationService.logout();
      this.toastr.info("از سامانه خارج شدید");
      this.router.navigate(['authentication/login']);
    }
  }

}
