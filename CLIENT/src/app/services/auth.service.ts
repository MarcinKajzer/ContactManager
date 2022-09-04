import { Injectable } from '@angular/core';
import { LoginInterface } from '../Interfaces/loginInterface';
import { RegisterInterface } from '../Interfaces/registerInterface'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient){}

  apiUrl: string = "";
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  login(loginData : LoginInterface){
    return this.http.post("https://localhost:7025/login", loginData);
  }

  logOut = () => {
    localStorage.removeItem("jwt");
  }

  register(registerData: RegisterInterface){
    return this.http.post("https://localhost:7025/register", registerData);
  }
}

