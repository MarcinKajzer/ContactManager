import { Component, OnInit } from '@angular/core';
import { ContactInterface } from '../Interfaces/contactInterface';
import { AuthService } from '../services/auth.service';
import { ContactService } from '../services/contact.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {

  isLoggedIn: boolean = false;

  contacts: Array<ContactInterface> = [];
  expandedContact: string = "";
  isFormVisible: boolean = false;
  
  isEdit: boolean = false;
  contactToEdit: ContactInterface | null = null;

  constructor(private contactsService: ContactService, private authService: AuthService) {
    this.authService.isLoggedIn.subscribe(value => this.isLoggedIn = value);
    this.authService.checkIfIsLoggedIn();
  }

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
    this.contactToEdit = null;
    this.isEdit = false;
  }

  editContact(contact: ContactInterface, event:any ){
    event.stopPropagation()

    this.contactToEdit = { ... contact };
    this.isEdit = true;
    this.isFormVisible = true;
  }

  deleteContact(email: string, event:any){
    event.stopPropagation();

    if (confirm("Are you sure you want to delete the contact ?")) {
      this.contactsService.delete(email);
    }
  }
}
