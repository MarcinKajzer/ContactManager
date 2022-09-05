import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CategoryInterface } from '../Interfaces/categoryInterface';
import { ContactInterface } from '../Interfaces/contactInterface';
import { ContactService } from '../services/contact.service';

@Component({
  selector: 'app-add-contact',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class AddContactComponent {

  constructor(private contactService: ContactService) { }

  contactCategories: Array<CategoryInterface> = [];
  contactSubCategories: Array<CategoryInterface> = [];

  initialContact: ContactInterface = {
    email: "",
    firstName: "",
    lastName: "",
    phoneNumber: "",
    categoryId: 1,
    dateOfBirth: "", 
    categoryName: "", 
    subCategoryId: 1, 
    subCategoryName: undefined
  }

  contact = { ... this.initialContact };

  @Input()
  contactInput = null;

  @Input()
  isEditForm = false;

  @Output()
  isFormVisible = new EventEmitter<boolean>();

  ngOnInit(): void {
    this.contactService.getContactCategories().subscribe(res => this.contactCategories = res);
    this.contactService.getContactSubCategories(1).subscribe(res => this.contactSubCategories = res);
  }

  ngOnChanges(){
    if(this.contactInput != null){
      this.contact = this.contactInput;
      this.selectCategory(this.contact.categoryId);
    }
    else{
      this.contact = { ... this.initialContact };
    }
  }

  selectCategory(categoryId: number){
    if(categoryId != 1)
      this.contact.subCategoryId = undefined;
    else
      this.contact.subCategoryId = 1;

    if(categoryId != 3){
      this.contact.subCategoryName = undefined;
    }
  }

  confirm(){
    if(this.isEditForm){
      this.contactService.update(this.contact);
    }
    else{
      this.contactService.create(this.contact);
    }
    
    this.contact =  { ... this.initialContact };
    this.isFormVisible.emit(false);
  }
}
