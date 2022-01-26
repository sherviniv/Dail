import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ActivityTimesListComponent } from "./activity-times-list/activity-times-list.component";

const routes: Routes = [
    { path: "", component: ActivityTimesListComponent },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ActivityTimesRoutingModule { }