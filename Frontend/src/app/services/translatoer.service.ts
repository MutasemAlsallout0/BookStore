import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ITranslatoer } from '../Interfaces/ITranslatoer';

@Injectable({
  providedIn: 'root'
})
export class TranslatoerService {
  baseUrl = environment.baseUrl+'/api/translator';
  constructor(private httpClient:HttpClient) { }


  getTranslatoers() {
    return this.httpClient.get<ITranslatoer[]>(this.baseUrl + '/GetTranslators');
  }

  addTranslatoer(translatoer:ITranslatoer) {
    return this.httpClient.post(this.baseUrl + '/addTranslator',translatoer);
  }
  deleteTranslatoer(translatoerId: number) {
    return this.httpClient.delete<boolean>(this.baseUrl + '/deleteTranslator' +'?id='+ translatoerId);
  }
}
