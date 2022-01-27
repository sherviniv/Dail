import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { AddTimeScheduleCommand, ModifyTimeScheduleCommand, TimeSchedulesClient } from 'src/app/core/services/dail.service';

@Component({
  selector: 'app-time-schedule-form',
  templateUrl: './time-schedule-form.component.html',
  styleUrls: ['./time-schedule-form.component.scss']
})
export class TimeScheduleFormComponent implements OnInit {
  model: AddTimeScheduleCommand | ModifyTimeScheduleCommand = {} as any;
  id: number | null = null;
  constructor(
    private toastr: ToastrService,
    private router: Router,
    private client: TimeSchedulesClient,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    if(this.id){
      this.loadModel();
    }
  }

  async loadModel(){
    this.spinner.show('main');
    await this.client.getById(this.id!).toPromise().then(
      response => {
        this.model = response;
      },
      error =>
        this.toastr.error("خطا در دریافت اطلاعات")
    );
    this.spinner.hide('main'); 
   }

  onsubmit(form: NgForm) {

    if (!form.valid) {
      return;
    }

    if (this.id) {
      this.update({ id: this.id, title: this.model.title, description: this.model.description } as any);
    } else {
      this.add(this.model);
    }
  }

  async add(command: AddTimeScheduleCommand) {
    this.spinner.show('main');
    await this.client.add(command).toPromise().then(
      response => {
        this.toastr.success("اطلاعات با موفقیت ثبت شد");
        this.router.navigate(['/panel/time-schedules']);
      },
      error =>
        this.toastr.error("خطا در ثبت اطلاعات")
    );
    this.spinner.hide('main');
  }

  async update(command: ModifyTimeScheduleCommand) {
    this.spinner.show('main');
    await this.client.modfiy(command).toPromise().then(
      response => {
        this.toastr.success("اطلاعات با موفقیت ثبت شد");
        this.router.navigate(['/panel/time-schedules']);
      },
      error =>
        this.toastr.error("خطا در ثبت اطلاعات")
    );
    this.spinner.hide('main');
  }
}