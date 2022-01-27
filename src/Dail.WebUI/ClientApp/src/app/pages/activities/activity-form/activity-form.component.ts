import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ActivitiesClient, AddActivityCommand, ModifyActivityCommand } from 'src/app/core/services/dail.service';

@Component({
  selector: 'app-activity-form',
  templateUrl: './activity-form.component.html',
  styleUrls: ['./activity-form.component.scss']
})
export class ActivityFormComponent implements OnInit {
  model: AddActivityCommand | ModifyActivityCommand = { color: '#ffffff'} as any;
  id: number | null = null;
  constructor(
    private toastr: ToastrService,
    private router: Router,
    private client: ActivitiesClient,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    if (this.id) {
      this.loadModel();
    }
  }

  async loadModel() {
    // this.spinner.show('main');
    // await this.client.getById(this.id!).toPromise().then(
    //   response => {
    //     this.model = response;
    //   },
    //   error =>
    //     this.toastr.error("خطا در دریافت اطلاعات")
    // );
    // this.spinner.hide('main');
  }

  onsubmit(form: NgForm) {

    if (!form.valid) {
      return;
    }
    
    if (this.id) {
      this.update(
        {
          id: this.id,
          title: this.model.title,
          description: this.model.description,
          color: this.model.color
        } as any);
    } else {
      this.add(this.model);
    }
  }

  async add(command: AddActivityCommand) {
    this.spinner.show('main');
    await this.client.add(command).toPromise().then(
      response => {
        this.toastr.success("اطلاعات با موفقیت ثبت شد");
        this.router.navigate(['/panel/activities']);
      },
      error =>
        this.toastr.error("خطا در ثبت اطلاعات")
    );
    this.spinner.hide('main');
  }

  async update(command: ModifyActivityCommand) {
    this.spinner.show('main');
    await this.client.modfiy(command).toPromise().then(
      response => {
        this.toastr.success("اطلاعات با موفقیت ثبت شد");
        this.router.navigate(['/panel/activities']);
      },
      error =>
        this.toastr.error("خطا در ثبت اطلاعات")
    );
    this.spinner.hide('main');
  }
}