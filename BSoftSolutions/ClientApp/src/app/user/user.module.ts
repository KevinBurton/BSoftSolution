import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from '../shared/shared.module';
import { UserEffects } from './state/user.effects';

import { UserComponent } from './containers/user/user.component';
import { LoginComponent } from '../login/containers/login/login.component';

import { userReducer } from './state/user.reducer';
import { EffectsModule } from '@ngrx/effects';
import { UserListComponent } from './components/user-list/user-list.component';

@NgModule({
  imports: [
    RouterModule.forChild([
        { path: 'users', component: UserComponent },
        { path: 'login', component: LoginComponent }
    ]),
    StoreModule.forFeature('user', userReducer),
    EffectsModule.forFeature(
      [ UserEffects ]
    ),
    SharedModule
  ],
  declarations: [
    LoginComponent,
    UserComponent,
    UserListComponent
  ]
})
export class UserModule { }
