import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { TimeSchedulesClient } from 'src/app/core/services/dail.service';
import { ColumnMode, SelectionType, TableColumn } from '@swimlane/ngx-datatable';
import { Router } from '@angular/router';
import { ConfirmDialogService } from 'src/app/shared/components/confirm-dialog/confirm-dialog.service';
import { PersianDatePipe } from 'src/app/core/pipes/persian-date.pipe';

@Component({
  selector: 'app-time-schedule-list',
  templateUrl: './time-schedule-list.component.html',
  styleUrls: ['./time-schedule-list.component.scss']
})
export class TimeScheduleListComponent implements OnInit {
  ColumnMode = ColumnMode;
  SelectionType = SelectionType
  selected: any = [];
  rows: any = [];
  columns: TableColumn[] = [
    { prop: 'title', name: 'عنوان' },
    { prop: 'created', name: 'تاریخ ثبت', pipe: new PersianDatePipe() },
    { prop: 'description', name: 'توضیحات' },
    { prop: 'lastModified', name: 'آخرین ویرایش' , pipe: new PersianDatePipe() }
  ];

  constructor(
    private client: TimeSchedulesClient,
    private toastr: ToastrService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private confirm: ConfirmDialogService) { }

  ngOnInit(): void {
    this.loadTable();
  }

  async loadTable() {
    this.spinner.show('main');
    await this.client.getTimeScheduleList().toPromise().then(
      response => {
        this.rows = response;
      },
      error =>
        this.toastr.error("خطا در دریافت اطلاعات")
    );
    this.spinner.hide('main');
  }

  edit() {
    this.router.navigate(['/panel/time-schedules/edit/' + this.selected[0].id]);
  }

  async remove() {
    let isConfirmed: boolean = await this.confirm.confirm("رکورد انتخابی حذف شود؟"
      , "برای خذف رکورد روی حذف کلیک کنید", "حذف", "لغو", "md");

    if (!isConfirmed) return;

    this.spinner.show('main');
    await this.client.remove({ id: this.selected[0].id! } as any).toPromise().then(
      response => {
        this.rows = response;
        this.toastr.info("با موفقیت ثبت شد")
        this.loadTable();
      },
      error =>
        this.toastr.error("خطا در حذف اطلاعات")
    );
    this.spinner.hide('main');
  }
}