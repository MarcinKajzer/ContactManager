import { Injectable } from '@angular/core';
import { LoginInterface } from '../Interfaces/loginInterface';
import { RegisterInterface } from '../Interfaces/registerInterface'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient){}

  private apiUrl: string = "https://localhost:7025";
  isLoggedIn = new Subject<boolean>;

  login(loginData : LoginInterface){
    return this.http.post(this.apiUrl + "/login", loginData);
  }

  logOut = () => {
    sessionStorage.removeItem("token");
    sessionStorage.removeItem("expires_at");
    this.isLoggedIn.next(false);
  }

  register(registerData: RegisterInterface){
    return this.http.post(this.apiUrl + "/register", registerData);
  }

  checkIfIsLoggedIn() {
    const expiration = sessionStorage.getItem("expires_at");

    if(expiration == null){
      this.isLoggedIn.next(false);
      return;
    }

    this.isLoggedIn.next(new Date(expiration) > new Date());
  }
}

