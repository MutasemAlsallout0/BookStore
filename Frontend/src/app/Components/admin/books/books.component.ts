import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IAuther } from 'src/app/Interfaces/IAuther';
import { AddBook, IBook } from 'src/app/Interfaces/IBooks';
import { ICategory } from 'src/app/Interfaces/ICategory';
import { IPublisher } from 'src/app/Interfaces/IPublisher';
import { ITranslatoer } from 'src/app/Interfaces/ITranslatoer';
import { AuthorService } from 'src/app/services/author.service';
import { BooksService } from 'src/app/services/books.service';
import { CategoryService } from 'src/app/services/category.service';
import { PublisherService } from 'src/app/services/publisher.service';
import { TranslatoerService } from 'src/app/services/translatoer.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  books: IBook[];
  BookForm: FormGroup;
  Authors: IAuther[];
  Publishers: IPublisher[];
  Translators: ITranslatoer[];
  Categories: ICategory[];
  progressValue: string;
  updateMood:boolean;

  constructor(
    private _bookService: BooksService,
    private _authorService: AuthorService,
    private _publisherService: PublisherService,
    private _translatorService: TranslatoerService,
    private _categoryService: CategoryService
  ) { }

  ngOnInit(): void {
    this.BookForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required]),
      price: new FormControl('', [Validators.required]),
      discount: new FormControl('', [Validators.required]),
      image: new FormControl('', [Validators.required]),
      fileSource: new FormControl('', [Validators.required]),
      about: new FormControl('', [Validators.required]),
      publishYear: new FormControl('', [Validators.required]),
      pageCount: new FormControl('', [Validators.required]),
      author: new FormControl('', [Validators.required]),
      publisher: new FormControl('', [Validators.required]),
      translator: new FormControl('', [Validators.required]),
      category: new FormControl('', [Validators.required]),
    });
    this.getPublishers();
    this.getAuthors();
    this.getTranslators();
    this.getCategories();
    this.getBooks();
  }

  reloadPage() {
    this.getBooks();
    this.BookForm.reset();
  }

  getBooks() {
    this._bookService.getBooks().subscribe({
      next: (data) => {
        this.books = data.map((item) => {
          console.log(item);
          return {
            ...item,
            image: environment.baseUrl+ 'Images/Thumbs/Small'+item.image ,
          };
        });
      },
    });
  }

  addBook() {
    let addBook : AddBook = this.BookForm.value;
    addBook.authorId = this.BookForm.value.author;
    addBook.publisherId = this.BookForm.value.publisher;
    addBook.categoryId = this.BookForm.value.category;
    addBook.translatorId = this.BookForm.value.translator;

    this._bookService.addBook(addBook).subscribe({
      next: (data) => {
        
        if (data == HttpEventType.Response) {
          this.reloadPage();
        }
      },
    });
  }

  onDelete(bookId: number) {
    this._bookService.deleteBook(bookId).subscribe((response) => {
      this.reloadPage();
    });
  }

  onUpdate(id: number) {
    this.BookForm.patchValue({
      name: this.books[id].name,
      price: this.books[id].price,
      discount: this.books[id].discount,
      about: this.books[id].about,
      publishYear: this.books[id].publishYear,
      pageCount: this.books[id].pageCount,
      author: 2,
      publisher : 1,
      translator: 1,
      category: 2,
    });
    
    this.updateMood = true;
  }

  onFileChange(event: Event) {
    const target = event.target as HTMLInputElement;
    const files = target.files!;
    if (files.length > 0) {
      const file = files[0];
      this.BookForm.patchValue({
        fileSource: file,
      });
    }
  }

  getAuthors() {
    this._authorService.getAuthors().subscribe({
      next: (response) => {
        this.Authors = response;
      },
    });
  }

  getPublishers() {
    this._publisherService.getPublishers().subscribe({
      next: (response) => {
        this.Publishers = response;
      },
    });
  }

  getTranslators() {
    this._translatorService.getTranslatoers().subscribe({
      next: (response) => {
        this.Translators = response;
      },
    });
  }

  getCategories() {
    this._categoryService.getCategories().subscribe({
      next: (response) => {
        this.Categories = response;
      },
    });
  }
  



}
