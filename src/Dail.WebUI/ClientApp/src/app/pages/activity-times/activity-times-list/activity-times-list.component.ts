import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ActivityTimesClient } from 'src/app/core/services/dail.service';
import { ColumnMode, SelectionType, TableColumn } from '@swimlane/ngx-datatable';
import { PersianDatePipe } from 'src/app/core/pipes/persian-date.pipe';
import { ToastrService } from 'ngx-toastr';
import { ConfirmDialogService } from 'src/app/shared/components/confirm-dialog/confirm-dialog.service';
import { WeekDayStringPipe } from 'src/app/core/pipes/weekday-string.pipe';

@Component({
  selector: 'app-time-schedule-list',
  templateUrl: './activity-times-list.component.html',
  styleUrls: ['./activity-times-list.component.scss']
})
export class ActivityTimesListComponent implements OnInit {
  ColumnMode = ColumnMode;
  SelectionType = SelectionType
  selected: any = [];
  rows: any = [];
  columns: TableColumn[] = [
    { prop: 'created', name: 'تاریخ ثبت', pipe: new PersianDatePipe() },
    { prop: 'title', name: 'عنوان' },
    { prop: 'startTime', name: 'از' },
    { prop: 'endTime', name: 'تا' },
    { prop: 'day', name: 'روز', pipe: new WeekDayStringPipe() },
    { prop: 'timeSchedulesTitle', name: 'برنامه زمانی' },
    { prop: 'lastModified', name: 'آخرین ویرایش' , pipe: new PersianDatePipe() }
  ];
  
  constructor(
    private client: ActivityTimesClient,
    private router: Router,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private confirm: ConfirmDialogService) { }

  ngOnInit(): void {
    this.loadTable();
  }

  async loadTable() {
    this.spinner.show('main');
    await this.client.getActivityTimesList().toPromise().then(
      response => {
        this.rows = response;
      },
      error =>
        this.toastr.error("خطا در دریافت اطلاعات")
    );
    this.spinner.hide('main');
  }

  edit() {
    this.router.navigate(['/panel/activity-times/edit/' + this.selected[0].id]);
  }

  async remove() {
    let isConfirmed: boolean = await this.confirm.confirm("رکورد انتخابی حذف شود؟"
      , "برای خذف رکورد روی حذف کلیک کنید", "حذف", "لغو", "md");

    if (!isConfirmed) return;

    this.spinner.show('main');
    await this.client.remove({ id: this.selected[0].id! } as any).toPromise().then(
      response => {
        this.rows = response;
        this.toastr.info("با موفقیت انجام شد")
        this.loadTable();
      },
      error =>
        this.toastr.error("خطا در حذف اطلاعات")
    );
    this.spinner.hide('main');
  }

}
