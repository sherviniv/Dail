import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from 'src/app/pages/authentication/services/authentication.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.authenticationService.currentUserValue;

        if (currentUser.token) {
            // check if route is restricted by role
            if (route.data.roles && route.data.roles.some((r: string) => currentUser.role.indexOf(r) === -1)) {

                // role not authorised so redirect to home page
                this.router.navigate(['authentication/login']);
                return false;
            }
            // authorised so return true
            return true;
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['authentication/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }

}
