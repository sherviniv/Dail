import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ScrollTopComponent } from './components/scroll-top/scroll-top.component';
import { ConfirmDialogService } from './components/confirm-dialog/confirm-dialog.service';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    SidebarComponent,
    NavbarComponent,
    ScrollTopComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    SidebarComponent,
    NavbarComponent,
    ScrollTopComponent
  ],
  providers: [
    ConfirmDialogService
  ]
})
export class SharedModule { }
