import { Component } from '@angular/core';
import { AuthService } from './shared/Services/auth.service';

@Component({
  selector: 'app-root',
  standalone: false,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  isLoggedin:boolean = false;
  title = 'Lumina';
  constructor(private authService:AuthService)
  {

  }
  ngOnInit(): void {
    this.authService.isLoggedIn$.subscribe((result) => {
      this.isLoggedin = result;
    });
  }
}
