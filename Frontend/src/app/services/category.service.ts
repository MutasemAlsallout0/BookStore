import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ICategory } from '../Interfaces/ICategory';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  baseUrl = environment.baseUrl+'/api/category';
  
  constructor(private http: HttpClient) {}

  getCategories() {
    return this.http.get<ICategory[]>(this.baseUrl + '/getCategories');
  }

  getCategoryById(categoryId: number) {
    this.http.get<ICategory>(this.baseUrl + 'Categories/' + categoryId);
  }

  addCategory(category: ICategory) {
    return this.http.post(this.baseUrl + '/addCategory', category);
  }

  updateCategory(categoryId: number,Name:string) {
    return this.http.put(this.baseUrl+'/updateCategory' + '?id='+categoryId ,{
      Name:Name
    });
  }

  deleteCategory(categoryId: number) {
    return this.http.delete<boolean>(this.baseUrl + '/deleteCategory' +'?id='+ categoryId);
  }
}
