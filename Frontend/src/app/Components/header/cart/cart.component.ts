import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IAuthResponse } from 'src/app/Interfaces/IAuthResponse';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
 

  constructor(private authService: AuthService,private router:Router ) { }

  ngOnInit(): void {
  }
  SignOut(){
    
    this.authService.logout();
    return this.router.navigate(['/login']); 
  }
  

}
