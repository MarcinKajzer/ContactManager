import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  isLoggedIn: boolean = false;
  
  constructor(private authService: AuthService){
    this.authService.isLoggedIn.subscribe(value => this.isLoggedIn = value);
    this.authService.checkIfIsLoggedIn();
  }

  logout(){
    this.authService.logOut();
  }

  title = 'CLIENT';
}
