import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IContactUs } from '../Interfaces/IContactUs';

@Injectable({
  providedIn: 'root'
})
export class ContactUsService {

  baseUrl = environment.baseUrl+'/api/contactUs';
  
  constructor(private httpClient: HttpClient) {}

  getContactUs() {
    return this.httpClient.get<IContactUs[]>(this.baseUrl + '/getContactUs');
  }

  getContactUsById(contactUsid: number) {
    this.httpClient.get<IContactUs>(this.baseUrl + 'getContactUsById/' + contactUsid);
  }

  addContactUs(bookSuggestion: IContactUs) {
    return this.httpClient.post(this.baseUrl + '/addContactUs', bookSuggestion);
  }

  updateContactUs(contactUsid: number,Name:string) {
    return this.httpClient.put(this.baseUrl+'/updateContactUs' + '?id='+contactUsid ,{
      Name:Name
    });
  }

  deleteContactUs(contactUsid: number) {
    return this.httpClient.delete<boolean>(this.baseUrl + '/deleteContactUs'+'?id='+ contactUsid);
  }
}
