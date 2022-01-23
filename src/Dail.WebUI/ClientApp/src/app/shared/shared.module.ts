import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ScrollTopComponent } from './components/scroll-top/scroll-top.component';

@NgModule({
  declarations: [
    SidebarComponent,
    NavbarComponent,
    ScrollTopComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    SidebarComponent,
    NavbarComponent,
    ScrollTopComponent
  ]
})
export class SharedModule { }
