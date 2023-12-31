import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from '../shared/Services/auth.service';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  userId: string = '';
  password: string = '';
  skipAuthCheck: boolean =  false;
constructor(private router:Router,private authService:AuthService, private snackBar:MatSnackBar){}
ngOnInit(): void { 
  this.authService.isLoggedIn$.subscribe();
  this.authService.skipAuthCheckSubject$.subscribe((result) =>
  {
    this.skipAuthCheck = result;
    if(!localStorage.getItem('token'))
    {
      this.skipAuthCheck = true;
    }
  })
  this.authService.isLoggedIn$.subscribe((result) => {
    if(result === true)
    {
      this.router.navigate(['']);
    }
    else
    {
      var result = this.authService.getLoggedIn();
      if(result)
        {
          this.authService.setLoggedIn(true);
        }
    }
  });
}
openSuccessMessage(message: string): void {
  this.snackBar.open(message, 'Close', {
    duration: 5000,
    verticalPosition: 'top',
    panelClass: ['success-snackbar'],
  });
}

login() {
    const data = {
      Username: this.userId,
      Password: this.password
    };
  
    this.authService.Login(data).subscribe(
      (response) => {
        const token = response.token;
        localStorage.setItem('token', token);
        this.authService.setLoggedIn(true);
        this.authService.setskipAuth(false);
        this.authService.setUserID(response.userId);
        this.router.navigate([''])
      },
      (error) => {
        this.openSuccessMessage('Login Failed!')
      }
    );
  }
}
