import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CoreModule } from 'src/app/core/core.module';
import { TimeSchedulesRoutingModule } from './time-schedules-routing.module';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { TimeScheduleFormComponent } from './time-schedule-form/time-schedule-form.component';
import { TimeScheduleListComponent } from './time-schedule-list/time-schedule-list.component';
import { AssignerComponent } from './assigner/assigner.component';
import { DndModule } from 'ngx-drag-drop';

@NgModule({
  declarations: [
    TimeScheduleListComponent,
    TimeScheduleFormComponent,
    AssignerComponent
  ],
  imports: [
    CoreModule,
    CommonModule,
    FormsModule,
    DndModule,
    NgxDatatableModule,
    TimeSchedulesRoutingModule
  ],
})
export class TimeSchedulesModule { }