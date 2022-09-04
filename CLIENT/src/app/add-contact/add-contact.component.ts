import { Component, OnInit } from '@angular/core';
import { ContactInterface } from '../Interfaces/contactInterface';
import { ContactService } from '../services/contact.service';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent{

  constructor(private contactService: ContactService) { }

  contact: ContactInterface = {
    email: "",
    firstName: "",
    lastName: "",
    phoneNumber: "",
    categoryId: 0,
    dateOfBirth: "", 
    categoryName: "", 
    subCategoryId: 0, 
    subCategoryName: ""
  }

  confirm(){
    this.contactService.create(this.contact);
  }
}
