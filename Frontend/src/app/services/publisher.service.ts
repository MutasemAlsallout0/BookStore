import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IPublisher } from '../Interfaces/IPublisher';

@Injectable({
  providedIn: 'root'
})
export class PublisherService {
  baseUrl = environment.baseUrl+'/api/publisher';
  constructor(private httpClient:HttpClient) { }

  getPublishers() {
    return this.httpClient.get<IPublisher[]>(this.baseUrl + '/getPublishers');
  }
  
  addPublisher(Name: string, Image: File) {
    let formData = new FormData();
    formData.append('Name', Name);
    formData.append('Logo', Image);
    return this.httpClient.post<IPublisher>(this.baseUrl+'/addPublisher', formData, 
    {
      reportProgress: true,
      observe: 'events',
    });
  }
}
