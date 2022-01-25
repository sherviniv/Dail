import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ReportsClient, UserDashboardViewModel } from 'src/app/core/services/dail.service';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.scss']
})
export class UserDashboardComponent implements OnInit {
  model: UserDashboardViewModel = {} as any;
  assignedActsPercentage: number = 0;

  constructor(
    private client: ReportsClient,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.loadDashboardInfo();
  }

  async loadDashboardInfo() {
    this.spinner.show('main');
    this.model = await this.client.getUserDashboard().toPromise();

    this.assignedActsPercentage = this.model.totalActivities == 0 ? 100 :
      (this.model.totalActivities - this.model.unAssignedWorksCount) * 100 / this.model.totalActivities;

    this.spinner.hide('main');
  }

}
