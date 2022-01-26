import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from 'src/app/pages/profile/profile.component';
import { UserDashboardComponent } from 'src/app/pages/user-dashboard/user-dashboard.component';
import { UserLayoutComponent } from './user-layout.component';

const routes: Routes = [
  {
    path: '',
    component: UserLayoutComponent,
    children: [
      { path: "", component: UserDashboardComponent },
      { path: "profile", component: ProfileComponent },
      {
        path: 'time-schedules',
        loadChildren: () => import('src/app/pages/time-schedules/time-schedules.module').then(mod => mod.TimeSchedulesModule)
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserLayoutRoutingModule { }
