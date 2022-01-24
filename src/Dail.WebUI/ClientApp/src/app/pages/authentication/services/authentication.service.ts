import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { User } from 'src/app/core/models';
import { AuthenticationClient, LoginDTO } from 'src/app/core/services/dail.service';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private client: AuthenticationClient) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser') ?? '{}'));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  async login(model: LoginDTO) {
    const token = await this.client.login(model).toPromise();
    const user = this.decodeJWT(token.data!);
    user.token = token;
    // store user details and jwt token in local storage to keep user logged in between page refreshes
    localStorage.setItem('dailcurrentUser', JSON.stringify(user));
    this.currentUserSubject.next(user);
  }

  private decodeJWT(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('dailcurrentUser');
    this.currentUserSubject.next({} as any);
  }
}
