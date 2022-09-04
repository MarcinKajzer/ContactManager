import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject, tap } from 'rxjs';
import { ContactInterface } from '../Interfaces/contactInterface';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) { }

  private address: string = "https://localhost:7025/Contacts";
  private contacts = new Subject<Array<ContactInterface>>();

  getContacts(){
    return this.contacts.asObservable();
  }

  get(email?: string){
    let address = email != null ? this.address += "/" + email : this.address;
  
    this.http.get<Array<ContactInterface>>(address).subscribe(res => this.contacts.next(res))
  }

  create(contact: ContactInterface){
    return this.http.post(this.address, contact);
  }
}
