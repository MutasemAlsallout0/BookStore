import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IAuther } from 'src/app/Interfaces/IAuther';
import { AuthorService } from 'src/app/services/author.service';

@Component({
  selector: 'app-auther',
  templateUrl: './auther.component.html',
  styleUrls: ['./auther.component.css']
})
export class AutherComponent implements OnInit {
authers!:IAuther[];
AutherForm!:FormGroup;
  constructor(private authorService:AuthorService) { }

  ngOnInit(): void {
    this.AutherForm=new FormGroup({
      name: new FormControl('', [Validators.required]),
    });
    this.getAuthers();
  }
  reloadPage() {
    this.getAuthers();
  }
  getAuthers() {
    this.authorService.getAuthors().subscribe((response) => {
      this.authers = response;
    });
  }
  addAuther() {
    this.authorService
      .addAuther(this.AutherForm.value)
      .subscribe((response) => {
        this.reloadPage();
      });
  }
  onDelete(autherId: number) {
    this.authorService.deleteAuther(autherId).subscribe((response) => {
      this.reloadPage();
    });
  }
}
