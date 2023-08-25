import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './Components/Home/home.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HeaderComponent } from './Components/header/header.component';
import { CartComponent } from './Components/header/cart/cart.component';
import { SearchBarComponent } from './Components/header/search-bar/search-bar.component';
import { MenuComponent } from './Components/header/menu/menu.component';
import { HeroComponent } from './Components/hero/hero.component';
import { MostOrderBooksComponent } from './Components/most-order-books/most-order-books.component';
import { AdBookComponent } from './Components/ad-book/ad-book.component';
import { BookItemComponent } from './Components/most-order-books/book-item/book-item.component';
import { SharedComponent } from './Components/shared/shared.component';
import { BookComponent } from './Components/shared/book/book.component';
import { PublisherComponent } from './Components/shared/publisher/publisher.component';
import { FooterComponent } from './Components/footer/footer.component';
import { AdminComponent } from './Components/admin/admin.component';
import { CategoryComponent } from './Components/admin/category/category.component';
import { AutherComponent } from './Components/admin/auther/auther.component';
import { DashboradComponent } from './Components/admin/dashborad/dashborad.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { TranslatoerComponent } from './Components/admin/translatoer/translatoer.component';
import { PublishersComponent } from './Components/admin/publishers/publishers.component';
import { BooksComponent } from './Components/admin/books/books.component';
import { RegisterComponent } from './Components/authentication/register/register.component';
import { LoginComponent } from './Components/authentication/login/login.component';
import { BookSuggestionComponent } from './Components/book-suggestion/book-suggestion.component';
import { ContactUsComponent } from './Components/contact-us/contact-us.component';


@NgModule({
  declarations: [AppComponent,
     HomeComponent, 
     HeaderComponent,
      SearchBarComponent,
      CartComponent,
       MenuComponent,
        HeroComponent,
         MostOrderBooksComponent,
          AdBookComponent,
           BookItemComponent,
            SharedComponent, 
            BookComponent,
             PublisherComponent,
              FooterComponent,
               AdminComponent, 
               CategoryComponent,
                AutherComponent, 
                DashboradComponent, 
                TranslatoerComponent, PublishersComponent, BooksComponent, RegisterComponent, LoginComponent, BookSuggestionComponent, ContactUsComponent],
  imports: [BrowserModule,
            AppRoutingModule,
             FontAwesomeModule,
             ReactiveFormsModule,
             HttpClientModule,
            ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
