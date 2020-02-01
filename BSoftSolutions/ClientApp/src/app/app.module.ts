import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { EffectsModule } from '@ngrx/effects';
import { InterceptorService } from './auth/interceptor.service';
import { AuthModule } from './auth/auth.module';
import { SharedModule } from './shared/shared.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AppRouteModule } from './app-route.module';
import { MovieModule } from './movie/movie.module';
import { GraphModule } from './graph/graph.module';
import { SignupComponent } from './signup/signup.component';
import { LoadingComponent } from './loading/loading.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    SignupComponent,
    LoadingComponent
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
    AuthModule,
    SharedModule
  ],
  providers: [
      { provide: HTTP_INTERCEPTORS, useClass: InterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
