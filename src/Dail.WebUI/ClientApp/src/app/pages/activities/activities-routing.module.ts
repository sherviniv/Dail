import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ActivitiesListComponent } from "./activities-list/activities-list.component";
import { ActivityFormComponent } from "./activity-form/activity-form.component";

const routes: Routes = [
    { path: "", component: ActivitiesListComponent },
    { path: "add", component: ActivityFormComponent },
    { path: "edit/:id", component: ActivityFormComponent },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ActivitiesRoutingModule { }