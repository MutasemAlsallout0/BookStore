import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ITranslatoer } from 'src/app/Interfaces/ITranslatoer';
import { TranslatoerService } from 'src/app/services/translatoer.service';

@Component({
  selector: 'app-translatoer',
  templateUrl: './translatoer.component.html',
  styleUrls: ['./translatoer.component.css']
})
export class TranslatoerComponent implements OnInit {
  translatoers!:ITranslatoer[];
  TranslatoerForm!:FormGroup;
  constructor(private translatoerService:TranslatoerService) { }

  ngOnInit(): void {
    this.TranslatoerForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
    });
    this.getTranslatoer();
  }

  reloadPage() {
    this.getTranslatoer();
  }

  getTranslatoer(){
    this.translatoerService.getTranslatoers().subscribe((response) => {
      this.translatoers = response;
  });
  }
  addTranslatoer(){
    this.translatoerService
    .addTranslatoer(this.TranslatoerForm.value)
    .subscribe((response )=>{
      this.reloadPage();
    });
  }
  onDelete(translatoerId: number) {
    this.translatoerService.deleteTranslatoer(translatoerId).subscribe((response) => {
      this.reloadPage();
    });
  }

}
