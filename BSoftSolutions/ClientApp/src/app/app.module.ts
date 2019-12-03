import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { EffectsModule } from '@ngrx/effects';

import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';

import { SharedModule } from './shared/shared.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AppRouteModule } from './app-route.module';
import { MovieModule } from './movie/movie.module';
import { GraphModule } from './graph/graph.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    StoreModule.forRoot({}, {
        runtimeChecks: {
            strictStateImmutability: true,
            strictActionImmutability: true,
            strictStateSerializability: true,
            strictActionSerializability: true,
        }
    }),
    StoreDevtoolsModule.instrument({
        name: 'BSoft',
        maxAge: 25,
        logOnly: environment.production
    }),
    EffectsModule.forRoot([]),
    MovieModule,
    GraphModule,
    AppRouteModule,
    SharedModule
  ],
  providers: [
//      { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
