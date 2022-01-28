import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { AddActivityTimeCommand, DayOfWeek, TimeSchedulesClient, TimeScheduleViewModel } from 'src/app/core/services/dail.service';

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
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute) { }

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

  removeItem($event : any, parent : any = null){

    if(parent == null){

    }
  }

}
