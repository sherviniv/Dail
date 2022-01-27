import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { TimeSchedulesClient } from 'src/app/core/services/dail.service';
import { ColumnMode, SortType, SelectionType, TableColumn } from '@swimlane/ngx-datatable';

@Component({
  selector: 'app-time-schedule-list',
  templateUrl: './time-schedule-list.component.html',
  styleUrls: ['./time-schedule-list.component.scss']
})
export class TimeScheduleListComponent implements OnInit {
  ColumnMode = ColumnMode;
  SelectionType = SelectionType
  selected = [];

  rows : any = [];

  title!: string | undefined;
  created!: Date;
  lastModified!: Date | undefined;

  columns: TableColumn[] = [
    { prop: 'title', name: 'عنوان' },
    { prop: 'created', name: 'تاریخ ثبت' },
    { prop: 'description', name: 'توضیحات' },
    { prop: 'lastModified', name: 'آخرین ویرایش' }
  ];

  constructor(
    private client: TimeSchedulesClient,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

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
        this.toastr.error("خطا در ثبت اطلاعات")
    );
    this.spinner.hide('main');
  }

  onSelect({ selected }: any) {
    console.log('Select Event', this.selected[0]);
  }

}
