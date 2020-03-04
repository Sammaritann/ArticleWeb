import { Component, OnInit } from '@angular/core';
import { LogUser } from 'src/app/model/user-model/logUser';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { error } from 'protractor';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  logUser = new LogUser("","");
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService, 
  ) { 

    if (this.authenticationService.currentUserValue) { 
      this.router.navigate(['/']);
  }
  }

  ngOnInit(){
  }

  onSubmit() {
      this.authenticationService.login(this.logUser).subscribe(user =>
        {
          this.router.navigate(['/']);
        }, error=>
          { 
            this.logUser.userName = '';
            this.logUser.password = '';
          });
        
  }

  onCancel()
  {

  }
}
