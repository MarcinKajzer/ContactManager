import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { LoginInterface } from '../Interfaces/loginInterface';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{

  constructor(private authService: AuthService) {}

  loginData : LoginInterface = {email: '', password: ''}

  confirm(){
    this.authService.login(this.loginData).subscribe(result => {
      sessionStorage.setItem("jwt", (<any>result).token);
    });
  }
}
