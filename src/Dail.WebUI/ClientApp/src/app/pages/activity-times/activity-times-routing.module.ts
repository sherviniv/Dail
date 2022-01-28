import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ActivityTimeFormComponent } from "./activity-time-form/activity-time-form.component";
import { ActivityTimesListComponent } from "./activity-times-list/activity-times-list.component";

const routes: Routes = [
    { path: "", component: ActivityTimesListComponent },
    { path: "add", component: ActivityTimeFormComponent },
    { path: "edit/:id", component: ActivityTimeFormComponent },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ActivityTimesRoutingModule { }