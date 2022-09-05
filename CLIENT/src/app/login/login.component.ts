import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { LoginInterface } from '../Interfaces/loginInterface';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{

  constructor(private authService: AuthService, private router: Router) {}

  loginData : LoginInterface = {email: '', password: ''}

  confirm(){
    this.authService.login(this.loginData).subscribe(
      result => {
        sessionStorage.setItem("token", (<any>result).token);
        sessionStorage.setItem("expires_at", (<any>result).expiration);
        this.authService.checkIfIsLoggedIn();

        this.router.navigate(['/contacts']);
      },
      error => {
        alert(error.error);
        this.loginData = {email: '', password: ''}
      });
  }
}
