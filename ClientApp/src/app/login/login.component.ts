import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [FormsModule]
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit() {
    this.authService.login(this.username, this.password).subscribe({
      next: response => {
        console.log('Login bem-sucedido:', response);
        this.router.navigate(['/users']);
      },
      error: error => {
        console.error('Erro de login:', error);
      }
    });
  }
}
