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
  isFormVisible: boolean = false;

  constructor(private contactsService: ContactService) { }

  ngOnInit(): void {
    this.contactsService.getContacts().subscribe(result => {
      this.contacts = result;
    });

    this.contactsService.get();
  }

  showDetails(email:string){
    this.expandedContact = this.expandedContact == email ? "" : email;
  }

  changeFormVisibility(isVisible: boolean){
    this.isFormVisible = isVisible;
  }
}
