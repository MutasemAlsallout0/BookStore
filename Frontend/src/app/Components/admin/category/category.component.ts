import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ICategory } from 'src/app/Interfaces/ICategory';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categories!: ICategory[];
  CategoryForm!: FormGroup;

  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    this.CategoryForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
    });
    this.getAllCategories();
  }

  reloadPage() {
    this.getAllCategories();
  }

  getAllCategories() {
    this.categoryService.getCategories().subscribe((response) => {
      this.categories = response;
    });
  }

  addCategory() {
    this.categoryService
      .addCategory(this.CategoryForm.value)
      .subscribe((response) => {
        this.reloadPage();
      });
  }
  OnUpdate(categoryId: number,Name:string){
    this.categoryService.updateCategory(categoryId,Name).subscribe((response)=>{
      this.reloadPage();
    })

  }

  onDelete(categoryId: number) {
    this.categoryService.deleteCategory(categoryId).subscribe((response) => {
      this.reloadPage();
    });
  }

}
