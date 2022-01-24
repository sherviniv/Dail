import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { Roles } from './core/models';
const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./pages/authentication/authentication.module').then(mod => mod.AuthenticationModule)
  },
  {
    path: 'authentication',
    loadChildren: () => import('./pages/authentication/authentication.module').then(mod => mod.AuthenticationModule)
  },
  {
    path: 'panel',
    loadChildren: () => import('./shared/layouts/user-layout/user-layout.module').then(mod => mod.UserLayoutModule),
    canActivate: [AuthGuard],
    data: { roles: [Roles.DailUser] }
  },
  {
    path: '**',
    redirectTo: 'not-found'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
