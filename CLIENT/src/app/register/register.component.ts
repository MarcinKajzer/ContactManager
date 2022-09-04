import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { RegisterInterface } from '../Interfaces/registerInterface';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent{

  constructor(private authService: AuthService){}

  registerData : RegisterInterface = {email: '', password: '', confirmPassword: ''}

  confirm(){
    this.authService.register(this.registerData);
  }
}
