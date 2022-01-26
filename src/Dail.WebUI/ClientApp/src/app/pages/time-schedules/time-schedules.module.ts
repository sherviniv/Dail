import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CoreModule } from 'src/app/core/core.module';
import { TimeSchedulesRoutingModule } from './time-schedules-routing.module';

@NgModule({
  declarations: [
  ],
  imports: [
    CoreModule,
    CommonModule,
    FormsModule,
    TimeSchedulesRoutingModule
  ]
})
export class TimeSchedulesModule { }