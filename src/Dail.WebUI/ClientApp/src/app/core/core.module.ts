import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { AuthenticationService } from '../pages/authentication/services/authentication.service';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { WeekDayStringPipe } from './pipes/weekday-string.pipe';
import { PersianDatePipe } from './pipes/persian-date.pipe';

@NgModule({
  declarations: [
    WeekDayStringPipe,
    PersianDatePipe
  ],
  providers :[
    AuthenticationService,
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  imports: [
    CommonModule,
    HttpClientModule,
  ],
  exports:[
    WeekDayStringPipe,
    PersianDatePipe
  ]
})
export class CoreModule { }
