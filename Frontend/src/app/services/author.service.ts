import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IAuther } from '../Interfaces/IAuther';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {
  baseUrl = environment.baseUrl+'/api/Author';
  constructor(private httpClient: HttpClient) { }
  getAuthors() {
    return this.httpClient.get<IAuther[]>(this.baseUrl + '/GetAuthors');
  }

  addAuther(auther:IAuther) {
    return this.httpClient.post(this.baseUrl + '/AddAuthor', auther);
  }
  deleteAuther(autherId: number) {
    return this.httpClient.delete<boolean>(this.baseUrl + '/deleteAuthor' +'?id='+ autherId);
  }
}
