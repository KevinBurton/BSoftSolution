import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginMenuComponent } from '../login-menu/login-menu.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HighlightModule } from 'ngx-highlightjs';
import json from 'highlight.js/lib/languages/json';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

export function hljsLanguages() {
  return [{ name: 'json', func: json }];
}

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule,
//    HighlightModule.forRoot({
//      languages: hljsLanguages
//    }),
    NgbModule,
    FontAwesomeModule
  ],
  declarations: [LoginMenuComponent],
  exports: [LoginMenuComponent]
})
export class AuthModule { }
