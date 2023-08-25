import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IBookSuggestion } from 'src/app/Interfaces/IBookSuggestion';
import { BookSuggestionService } from 'src/app/services/book-suggestion.service';

@Component({
  selector: 'app-book-suggestion',
  templateUrl: './book-suggestion.component.html',
  styleUrls: ['./book-suggestion.component.css']
})
export class BookSuggestionComponent implements OnInit {
  BookSuggestion!: IBookSuggestion[];
  BookSuggestionForm!: FormGroup;
  constructor(private bookSuggestionService: BookSuggestionService) { }

  ngOnInit(): void {
    this.BookSuggestionForm = new FormGroup({
      bookName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      publisherName: new FormControl('', [Validators.required]),
      authorName: new FormControl('', [Validators.required]),
      notes: new FormControl('', [Validators.required]),
    });
    this.getBookSuggestions();
  }
  reloadPage() {
    this.getBookSuggestions();
  }

  getBookSuggestions() {
    this.bookSuggestionService.getBookSuggestion().subscribe((response) => {
      this.BookSuggestion = response;
    });
  }

  addBookSuggestion() {
    this.bookSuggestionService
      .addBookSuggestion(this.BookSuggestionForm.value)
      .subscribe((response) => {
        this.reloadPage();
      });
  }

  onDelete(bookSuggestionId: number) {
    this.bookSuggestionService.deleteBookSuggestion(bookSuggestionId).subscribe((response) => {
      this.reloadPage();
    });
  }

}
