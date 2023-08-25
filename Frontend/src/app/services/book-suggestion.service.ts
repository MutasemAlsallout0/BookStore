import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IBookSuggestion } from '../Interfaces/IBookSuggestion';

@Injectable({
  providedIn: 'root'
})
export class BookSuggestionService {
  baseUrl = environment.baseUrl+'/api/bookSuggestions';

  constructor(private httpClient: HttpClient) { }

  getBookSuggestion() {
    return this.httpClient.get<IBookSuggestion[]>(this.baseUrl + '/getBookSuggestions');
  }

  getBookSuggestionById(bookSuggestionId: number) {
    this.httpClient.get<IBookSuggestion>(this.baseUrl + 'getBookSuggestionById/' + bookSuggestionId);
  }
  addBookSuggestion(bookSuggestion: IBookSuggestion) {
    return this.httpClient.post(this.baseUrl + '/addBookSuggestion', bookSuggestion);
  }

  updateBookSuggestion(bookSuggestionId: number,Name:string) {
    return this.httpClient.put(this.baseUrl+'/updateBookSuggestion' + '?id='+bookSuggestionId ,{
      Name:Name
    });
  }

  deleteBookSuggestion(bookSuggestionId: number) {
    return this.httpClient.delete<boolean>(this.baseUrl + '/deleteBookSuggestion'+'?id='+ bookSuggestionId);
  }
}
