import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ActivitiesClient, ActivityTimesClient, ActivityTimeViewModel, ActivityViewModel, DayOfWeek, IActivityViewModel, TimeSchedulesClient, TimeScheduleViewModel } from 'src/app/core/services/dail.service';

@Component({
  selector: 'app-assigner',
  templateUrl: './assigner.component.html',
  styleUrls: ['./assigner.component.scss']
})
export class AssignerComponent implements OnInit {
  id: number | null = null;
  model: TimeScheduleViewModel = {} as any;
  DayOfWeek = DayOfWeek;
  days(): Array<any> {
    var values = Object.values(this.DayOfWeek);
    return values.slice(values.length / 2);
  }

  constructor(
    private toastr: ToastrService,
    private client: TimeSchedulesClient,
    private activityTimeClient: ActivityTimesClient,
    private activityClient: ActivitiesClient,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.getInfo();
  }

  async getInfo() {
    this.spinner.show('main');
    await this.client.getTimeSchedule(this.id!).toPromise().then(
      response => {
        this.model = response;
      },
      error =>
        this.toastr.error("خطا در دریافت اطلاعات")
    );
    this.spinner.hide('main');
  }

  async removeItem($event: any) {
    if ($event.type == 'activity') {
      await this.activityClient.remove({ id: $event.data.id } as any)
        .toPromise().then(
          response => {

          },
          error =>
            this.toastr.error("خطا در حذف اطلاعات")
        );
    } else if ($event.type == 'activityTime') {
      await this.activityTimeClient.remove({ id: $event.data.id } as any)
        .toPromise().then(
          response => {
          },
          error =>
            this.toastr.error("خطا در حذف اطلاعات")
        )
    }
    this.getInfo();
  }

  onActivityMoved(item: ActivityViewModel, list: ActivityViewModel[], effect: any) {
    if (effect === "move") {
      const index = list.indexOf(item);
      list.splice(index, 1);
    }
  }

  async moveActivityTime($event: any, day: DayOfWeek) {
    if ($event.data.day >= 0 && $event.data.day != day) {
      let model = this.model.activityTimes!.find(c => c.id == $event.data.id)!;
      model.day = day;
      await this.activityTimeClient.modfiy(model)
        .toPromise().then(
          response => {
          },
          error =>
            this.toastr.error("خطا در ثبت اطلاعات")
        );
    }
  }

  async setTime($event: any, activityTime: ActivityTimeViewModel) {
    let model = $event.data as IActivityViewModel;
    model.created = new Date;
    model.lastModified = new Date;

    await this.activityClient.assign({ activityId: model.id, activityTimeId: activityTime.id } as any)
      .toPromise().then(
        response => {
          activityTime.activities?.push(new ActivityViewModel(model));
        },
        error =>
          this.toastr.error("خطا در ثبت اطلاعات")
      );
  }

  async removeTime($event: any) {
    let model = $event.data as IActivityViewModel;
    model.created = new Date;
    model.lastModified = new Date;
    await this.activityClient.assign({ activityId: model.id, activityTimeId: null } as any)
      .toPromise().then(
        response => {
          this.model.unAssignedActivities?.push(new ActivityViewModel(model));
        },
        error =>
          this.toastr.error("خطا در ثبت اطلاعات")
      );
  }

  sortBy(prop: string, list: any[], day: any) {
    return list.filter(c => c.day == day).sort((a, b) => a[prop] > b[prop] ? 1 : a[prop] === b[prop] ? 0 : -1);
  }
}
