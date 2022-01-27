import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ActivityTimesClient } from 'src/app/core/services/dail.service';
import { ColumnMode, SelectionType, TableColumn } from '@swimlane/ngx-datatable';
import { PersianDatePipe } from 'src/app/core/pipes/persian-date.pipe';
import { ToastrService } from 'ngx-toastr';

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
    { prop: 'day', name: 'روز' },
    { prop: 'timeSchedulesTitle', name: 'برنامه زمانی' },
    { prop: 'lastModified', name: 'آخرین ویرایش' , pipe: new PersianDatePipe() }
  ];
  
  constructor(
    private client: ActivityTimesClient,
    private router: Router,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

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

}
