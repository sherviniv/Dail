import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { ServerResult } from '../models';
import { AuthenticationService } from 'src/app/pages/authentication/services/authentication.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private authenticationService: AuthenticationService, private toastr: ToastrService, private spinner: NgxSpinnerService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError((err: HttpErrorResponse) => {
      
      if (err.status === 0) {
        this.toastr.error("Can not connect to server", err.status.toString());
      }

      if ([401, 403].indexOf(err.status) !== -1) {
        // auto logout if 401 Unauthorized or 403 Forbidden response returned from api
        this.toastr.warning("Unauthorized request", err.status.toString());
        this.authenticationService.logout();
        location.reload();
      }

      err.error.text().then((reqBody: string | any) => {
        let res: ServerResult;
        reqBody = reqBody && reqBody.length > 0 ? reqBody : null;
        res = err.headers.get('Content-type') == 'application/json' ?
          JSON.parse(reqBody) : { message: 'Failed to send request' };

        if (err.status === 500) {
          this.toastr.error(res.message, "Error");
        }

        if (err.status === 400) {
          if (res.errors){
            Object.getOwnPropertyNames(res.errors).forEach( 
              validationItem =>  res.errors[validationItem].forEach((c: any)=> this.toastr.warning(c)))
          }
          else
            this.toastr.info(res.message);
        }

        if (err.status === 404) {
          this.toastr.info(res.message);
        }

        if (err.status === 429) {
          this.toastr.info(res.message);
        }

      });

      this.spinner.hide("main");
      const error = err.error.message || err.statusText;
      return throwError(error);
    }))
  }

}