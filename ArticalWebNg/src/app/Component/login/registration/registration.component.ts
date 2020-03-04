import { Component, OnInit } from '@angular/core';
import { RegUser } from 'src/app/model/user-model/regUser';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  regUser = new RegUser("","","","");

  constructor(    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService, ) { }

  ngOnInit(): void {
    if (this.authenticationService.currentUserValue) { 
      this.authenticationService.logout();
    }
  }

  onSubmit(){

    this.authenticationService.register(this.regUser).subscribe(user =>
      {
        this.router.navigate(['/']);
      }, error=>
        {
          this.regUser.userName = '';
          this.regUser.password = '';
          this.regUser.confirmPassword = ``;
          this.regUser.email = ``;
        });
}

}
