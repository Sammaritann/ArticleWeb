import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../model/user-model/user';
import { LogUser } from '../model/user-model/logUser';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { RegUser } from '../model/user-model/regUser';
import { ResetPasswordUser } from '../model/user-model/reserPasswrodUser';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
 
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
 
  
  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router,
    ) {
      this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
      this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
}



login(logUser:LogUser) {
   return this.http.post<User>(`${environment.authUrl}/users/login`,logUser).pipe(map(user => {

    if (user && user.token) {
        
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
    }

    return user;
}));
}

register(regUser:RegUser)
{
  return this.http.post<User>(`${environment.authUrl}/users/register`,regUser).pipe(map(user => {

    if (user && user.token) {
        
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
    }

    return user;
}));
  
}

resetPasswrod(logUser:LogUser):Observable<any>
{
  var resUser = new ResetPasswordUser(logUser.userName);
  return this.http.post(`${environment.authUrl}/users/resetPassword`,resUser);
}

logout() {

    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
}
}
