import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { UserListComponent } from './user/user-list.component';


export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'users', component: UserListComponent },
  { path: '', redirectTo: '/users', pathMatch: 'full' }, // Redireciona para a tela de usuários
  { path: '**', redirectTo: '/users' } // Redireciona para usuários caso a rota não seja encontrada
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
