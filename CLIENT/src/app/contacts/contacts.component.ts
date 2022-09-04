import { Component, OnInit } from '@angular/core';
import { ContactInterface } from '../Interfaces/contactInterface';
import { ContactService } from '../services/contact.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {

  contacts: Array<ContactInterface> = [];
  expandedContact: string = "";

  constructor(private contactsService: ContactService) { }

  ngOnInit(): void {
    this.contactsService.get().subscribe(result => {
      console.log(result);
      this.contacts = result;
    })
  }

  showDetails(email:string){
    this.expandedContact = email;
  }

}
