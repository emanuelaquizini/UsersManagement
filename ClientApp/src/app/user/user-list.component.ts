import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service'; 
import { User } from './user.model';        
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-user-list',
  standalone: true,
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  imports: [NgFor, NgIf],
  providers: [UserService]
})
export class UserListComponent implements OnInit {
  users: User[] = []; 
  errorMessage: string = '';

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loadUsers();
  }


  loadUsers(): void {
    this.userService.getUsers().subscribe(
      (data: User[]) => {
        this.users = data; 
      },
      (error) => {
        this.errorMessage = 'Erro ao carregar usuários'; 
        console.error(error);
      }
    );
  }
}
