import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserLayoutComponent } from './user-layout.component';
import { UserDashboardComponent } from 'src/app/pages/user-dashboard/user-dashboard.component';
import { SharedModule } from '../../shared.module';
import { UserLayoutRoutingModule } from './user-layout.routing.module';

@NgModule({
  declarations: [
    UserLayoutComponent,
    UserDashboardComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    UserLayoutRoutingModule,
    FormsModule,
  ], providers: []
})
export class UserLayoutModule { }
