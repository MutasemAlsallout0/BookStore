import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AddBook, IBook } from '../Interfaces/IBooks';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  baseUrl = environment.baseUrl + '/api/book/';
  constructor(private httpClinent: HttpClient) { }

  
  getBooks() {
    return this.httpClinent.get<IBook[]>(this.baseUrl + 'getBook');
  }

  getBookById(bookId: number) {
    this.httpClinent.get<IBook>(this.baseUrl + 'getBookById/' + bookId);
  }

  addBook(book: AddBook) {
    return this.httpClinent.post(this.baseUrl + 'addBook', book);
  }

  updateBook() {}

  deleteBook(bookId: number) {
    return this.httpClinent.delete<boolean>(this.baseUrl + 'deleteBook/' + bookId);
  }
}
