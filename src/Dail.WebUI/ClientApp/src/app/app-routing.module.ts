import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { Roles } from './core/models';
import { NotFoundComponent } from './pages/not-found/not-found.component';
const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
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
  { path: 'not-found', component: NotFoundComponent, pathMatch: 'full', data: { title: '404 not found' } },
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
