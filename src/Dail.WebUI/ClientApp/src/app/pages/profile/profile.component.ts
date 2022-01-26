import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserDTO } from 'src/app/core/services/dail.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  model: UserDTO = {} as any;

  constructor() { }

  ngOnInit(): void {
  }

  onsubmit(f: NgForm) {

      (f.controls["password"].value &&
        f.controls["cpassword"].value !== f.controls["password"].value)
      return;
  }

}
