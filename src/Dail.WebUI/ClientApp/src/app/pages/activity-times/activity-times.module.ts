import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CoreModule } from 'src/app/core/core.module';
import { ActivityTimesRoutingModule } from './activity-times-routing.module';
import { ActivityTimesListComponent } from './activity-times-list/activity-times-list.component';

@NgModule({
  declarations: [
    ActivityTimesListComponent
  ],
  imports: [
    CoreModule,
    CommonModule,
    FormsModule,
    ActivityTimesRoutingModule
  ]
})
export class ActivityTimesModule { }