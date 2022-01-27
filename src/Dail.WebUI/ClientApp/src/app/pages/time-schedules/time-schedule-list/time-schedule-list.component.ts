import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { TimeSchedulesClient } from 'src/app/core/services/dail.service';
import { ColumnMode, SortType, SelectionType } from '@swimlane/ngx-datatable';

@Component({
  selector: 'app-time-schedule-list',
  templateUrl: './time-schedule-list.component.html',
  styleUrls: ['./time-schedule-list.component.scss']
})
export class TimeScheduleListComponent implements OnInit {
  ColumnMode = ColumnMode;
  SelectionType = SelectionType
  selected = [];

  rows = [
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Austin', gender: 'Male', company: 'Swimlane' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },

    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Dany', gender: 'Male', company: 'KFC' },
    { name: 'Molly', gender: 'Female', company: 'Burger King' }
  ];
  columns = [{ prop: 'name', name: 'نام' }, { name: 'Gender' }, { name: 'Company' }];

  constructor(
    private client: TimeSchedulesClient,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
  }

  async loadTable() {
    this.spinner.show('main');
    await this.client.getTimeScheduleList().toPromise().then(
      response => {
      },
      error =>
        this.toastr.error("خطا در ثبت اطلاعات")
    );
    this.spinner.hide('main');
  }

  onSelect({ selected } : any) {
    console.log('Select Event', this.selected[0]);
  }

}
