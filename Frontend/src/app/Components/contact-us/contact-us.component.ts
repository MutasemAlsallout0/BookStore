import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IContactUs } from 'src/app/Interfaces/IContactUs';
import { ContactUsService } from 'src/app/services/contact-us.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {

  ContactUs!: IContactUs[];
  ContactUsForm!: FormGroup;
  constructor(private contactUsService: ContactUsService) { }

  ngOnInit(): void {
    this.ContactUsForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      message: new FormControl('', [Validators.required]),
      fullName: new FormControl('', [Validators.required]),
    });
    this.getContactUss();
  }

  reloadPage() {
    this.getContactUss();
  }

  getContactUss() {
    this.contactUsService.getContactUs().subscribe((response) => {
      this.ContactUs = response;
    });
  }

  addContactUs() {
    this.contactUsService
      .addContactUs(this.ContactUsForm.value)
      .subscribe((response) => {
        this.reloadPage();
      });
  }

  onDelete(contactUsId: number) {
    this.contactUsService.deleteContactUs(contactUsId).subscribe((response) => {
      this.reloadPage();
    });
  }

}
