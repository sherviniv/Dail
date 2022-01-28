import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AssignerComponent } from "./assigner/assigner.component";
import { TimeScheduleFormComponent } from "./time-schedule-form/time-schedule-form.component";
import { TimeScheduleListComponent } from "./time-schedule-list/time-schedule-list.component";

const routes: Routes = [
    { path: "", component: TimeScheduleListComponent },
    { path: "add", component: TimeScheduleFormComponent },
    { path: "edit/:id", component: TimeScheduleFormComponent },
    { path: "assign/:id", component: AssignerComponent },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class TimeSchedulesRoutingModule { }