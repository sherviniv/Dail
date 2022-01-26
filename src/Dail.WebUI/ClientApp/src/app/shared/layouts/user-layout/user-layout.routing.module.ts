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
      {
        path: 'activities',
        loadChildren: () => import('src/app/pages/activities/activities.module').then(mod => mod.ActivitiesModule)
      },
      {
        path: 'activity-times',
        loadChildren: () => import('src/app/pages/activity-times/activity-times.module').then(mod => mod.ActivityTimesModule)
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserLayoutRoutingModule { }
