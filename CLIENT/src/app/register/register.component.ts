import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { RegisterInterface } from '../Interfaces/registerInterface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent{

  constructor(private authService: AuthService, private router: Router){}

  registerData : RegisterInterface = {email: '', password: '', confirmPassword: ''}

  confirm(){
    this.authService.register(this.registerData).subscribe(
      result => {
        alert((<any>result).message);
        this.router.navigate(['/login']);
      }, 
      error => {
        alert(error.error);
        this.registerData = {email: '', password: '', confirmPassword: ''};
      });
  }
}
