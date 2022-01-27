import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from 'src/app/core/core.module';
import { FormsModule } from '@angular/forms';
import { ActivityFormComponent } from './activity-form/activity-form.component';
import { ActivitiesListComponent } from './activities-list/activities-list.component';
import { ActivitiesRoutingModule } from './activities-routing.module';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgxColorsModule } from 'ngx-colors';

@NgModule({
  declarations: [
    ActivitiesListComponent,
    ActivityFormComponent
  ],
  imports: [
    CoreModule,
    CommonModule,
    FormsModule,
    NgxDatatableModule,
    NgxColorsModule,
    ActivitiesRoutingModule
  ]
})
export class ActivitiesModule { }