import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ILoginRequest } from 'src/app/Interfaces/ILoginRequest ';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  submitted = false;
  showError: boolean;
  errorMessage: string;
  loginForm: FormGroup;
  constructor(private router: Router,
     private route: ActivatedRoute,
     private authService: AuthService,
     private formBuilder: FormBuilder) { }
     get f() { return this.loginForm.controls; }


  

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
    });
  }

  validateControl(controlName: string) {
    return (
      this.loginForm.get(controlName)?.invalid &&
      this.loginForm.get(controlName)?.touched
    );
  }

  hasError(controlName: string, errorName: string) {
    return this.loginForm.get(controlName)?.hasError(errorName);
  }

  loginUser() {
    this.submitted = true;
    this.showError = false;
    const login = { ...this.loginForm.value };
    const userForAuth: ILoginRequest = {
      email: login.email,
      password: login.password,
    };

    this.authService.loginUser(userForAuth).subscribe({
      next: (data) => {
        console.log(data);
        var returnUrl = this.route.snapshot.queryParams['returnUrl'];
        if (returnUrl) this.router.navigate([returnUrl]);
        else this.router.navigate(['/']);
        this.authService.saveToken(data);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

}
