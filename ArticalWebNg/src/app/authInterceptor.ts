import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthenticationService } from './Services/authentication.service';
import { Router } from '@angular/router';
import { ThrowStmt } from '@angular/compiler';


@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private router: Router,
      private  authService:AuthenticationService) {
    }

    intercept(req: HttpRequest<any>,
              next: HttpHandler): Observable<HttpEvent<any>> {

         var user= JSON.parse(localStorage.getItem('currentUser'));
        var cloned = req;
        if (user) {
           const idToken = user.token;
             cloned = req.clone({
                headers: req.headers.set("Authorization",
                    "Bearer " + idToken)
            });
        }
            return next.handle(cloned)
            .pipe(
                catchError(error=>{
                    switch(error.status)
                    {
                        case 401:
                            this.authService.logout();
                            this.router.navigateByUrl("/login");
                            break;
                    }
                    return throwError(error)
                })
            );
    }
}