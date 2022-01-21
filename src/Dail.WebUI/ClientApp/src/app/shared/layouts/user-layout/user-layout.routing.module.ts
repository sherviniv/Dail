import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    // {
    //     path: '',
    //     component: UserLayoutComponent,
    //     children: [
    //       { path: "counter", component: CounterComponent },
    //       { path: "fetch-data", component: FetchDataComponent },
    //     ]
    // }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserLayoutRoutingModule { }
