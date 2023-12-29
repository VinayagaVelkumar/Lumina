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
constructor(private router:Router,private authService:AuthService, private snackBar:MatSnackBar){}
ngOnInit(): void { 
  this.authService.isLoggedIn$.subscribe();
  this.authService.isLoggedIn$.subscribe((result) => {
    if(result === true)
    {
      this.router.navigate([''])
    }
    else
    {
      this.authService.authorize().subscribe((auth:boolean) => {
        if(auth === true)
        {
          this.authService.setLoggedIn(true);
        }
      });
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
        this.router.navigate([''])
      },
      (error) => {
        this.openSuccessMessage('Login Failed!')
      }
    );
  }
}
