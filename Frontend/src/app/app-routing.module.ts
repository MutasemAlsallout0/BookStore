import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './Components/admin/admin.component';
import { AutherComponent } from './Components/admin/auther/auther.component';
import { CategoryComponent } from './Components/admin/category/category.component';
import { DashboradComponent } from './Components/admin/dashborad/dashborad.component';
import { PublishersComponent } from './Components/admin/publishers/publishers.component';
import { TranslatoerComponent } from './Components/admin/translatoer/translatoer.component';
 import { HomeComponent } from './Components/Home/home.component';
import { PublisherComponent } from './Components/shared/publisher/publisher.component';
import { BooksComponent } from './Components/admin/books/books.component';
import { LoginComponent } from './Components/authentication/login/login.component';
import { RegisterComponent } from './Components/authentication/register/register.component';
import { AuthGuard } from './guards/auth.guard';
import { AdminGuard } from './guards/admin.guard';
import { BookSuggestionComponent } from './Components/book-suggestion/book-suggestion.component';
import { ContactUsComponent } from './Components/contact-us/contact-us.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full',
  },
  {
    path:'admin',
    component:AdminComponent,
    //canActivateChild: [AuthGuard, AdminGuard],
    children:[
      {
        path:'Dashborad',
        component:DashboradComponent

      },
      {path:'category',
      component:CategoryComponent
      },
      {
        path:'auther',
        component:AutherComponent
      },
      {
        path:'translatoer',
        component:TranslatoerComponent
      },
      {
        path:'publishers',
        component:PublishersComponent
      },
      {
        path:'book',
        component:BooksComponent
      }
    
    ]
  },
  {
    path : 'login',
    component:LoginComponent
  },
  {
    path: 'register',
    component:RegisterComponent
  },
  {
    path: 'BookSuggestion',
    component:BookSuggestionComponent
  },
  {
    path:'ContactUs',
    component: ContactUsComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
