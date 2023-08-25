import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateChild, Route, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivateChild {
  constructor (private authService: AuthService, private router : Router){}
  canActivateChild(childRoute: ActivatedRouteSnapshot,state: RouterStateSnapshot): 
                  boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
      if (this.authService.isUserAdmin()) {
        return true;
      }
      this.router.navigate(['/forbidden']);
      return false;
    }

  
}
