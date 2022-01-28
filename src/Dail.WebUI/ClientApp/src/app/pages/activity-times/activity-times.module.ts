import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CoreModule } from 'src/app/core/core.module';
import { ActivityTimesRoutingModule } from './activity-times-routing.module';
import { ActivityTimesListComponent } from './activity-times-list/activity-times-list.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ActivityTimeFormComponent } from './activity-time-form/activity-time-form.component';

@NgModule({
  declarations: [
    ActivityTimesListComponent,
    ActivityTimeFormComponent
  ],
  imports: [
    CoreModule,
    CommonModule,
    FormsModule,
    NgxDatatableModule,
    ActivityTimesRoutingModule
  ]
})
export class ActivityTimesModule { }