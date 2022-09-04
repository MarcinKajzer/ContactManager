import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ContactInterface } from '../Interfaces/contactInterface';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) { }

  get(email?: string){
    
    let address = "https://localhost:7025/Contacts";
    if(email)
      address += "/" + email;

    return this.http.get<Array<ContactInterface>>(address);
  }
}
