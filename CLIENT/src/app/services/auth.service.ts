import { Injectable } from '@angular/core';
import { LoginInterface } from '../Interfaces/loginInterface';
import { RegisterInterface } from '../Interfaces/registerInterface'

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isLoggedIn = false;

  login(loginData : LoginInterface){
    console.log(loginData);
  }

  register(registerData: RegisterInterface){
    console.log(registerData);
  }
}
