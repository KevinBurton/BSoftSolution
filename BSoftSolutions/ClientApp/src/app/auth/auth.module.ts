import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginMenuComponent } from '../login-menu/login-menu.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule,
    NgbModule,
    FontAwesomeModule
  ],
  declarations: [LoginMenuComponent],
  exports: [LoginMenuComponent]
})
export class AuthModule { }
