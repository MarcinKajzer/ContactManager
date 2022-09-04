import { Component} from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent{

  registerData = {
    email: '',
    password: '',
    confirmPassword: ''
  }

  confirm(){
    console.log(this.registerData)
  }
}
