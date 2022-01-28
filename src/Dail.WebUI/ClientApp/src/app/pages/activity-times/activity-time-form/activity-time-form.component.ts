import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ActivityTimesClient, AddActivityTimeCommand, DayOfWeek, ModifyActivityTimeCommand } from 'src/app/core/services/dail.service';

@Component({
  selector: 'app-activity-time-form',
  templateUrl: './activity-time-form.component.html',
  styleUrls: ['./activity-time-form.component.scss']
})
export class ActivityTimeFormComponent implements OnInit {
  model: AddActivityTimeCommand = {} as any;
  id: number | null = null;
  timeScheduleId: number | null = null;
  returnUrl: string = '/panel/activity-times';
  DayOfWeek = DayOfWeek;
  days(): Array<any> {
    var values = Object.values(this.DayOfWeek);
    return values.slice(values.length / 2);
  }

  constructor(
    private toastr: ToastrService,
    private router: Router,
    private client: ActivityTimesClient,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    const timeScheduleId = this.route.snapshot.queryParams['timescheduleid'];
    if (timeScheduleId){
      this.returnUrl= '/panel/time-schedules/assign/'+ timeScheduleId;
      this.model.timeScheduleId = timeScheduleId;
    }

    if (this.id) {
      this.loadModel();
    }
  }

  async loadModel() {
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

    this.model.day = Number.parseInt(this.model.day.toString());

    if (this.id) {
      this.update(
        {
          id: this.id,
          title: this.model.title,
          startTime: this.model.startTime,
          endTime: this.model.endTime
        } as any);
    } else {
      this.add(this.model);
    }
  }

  async add(command: AddActivityTimeCommand) {
    this.spinner.show('main');
    await this.client.add(command).toPromise().then(
      response => {
        this.toastr.success("اطلاعات با موفقیت ثبت شد");
        this.router.navigate([this.returnUrl]);
      },
      error =>
        this.toastr.error("خطا در ثبت اطلاعات")
    );
    this.spinner.hide('main');
  }

  async update(command: ModifyActivityTimeCommand) {
    this.spinner.show('main');
    await this.client.modfiy(command).toPromise().then(
      response => {
        this.toastr.success("اطلاعات با موفقیت ثبت شد");
        this.router.navigate([this.returnUrl]);
      },
      error =>
        this.toastr.error("خطا در ثبت اطلاعات")
    );
    this.spinner.hide('main');
  }

}