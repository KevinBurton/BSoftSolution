import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { User } from '../models/user';
import { MessageService } from '../messages/message.service';
import { Store, select } from '@ngrx/store';
import { Subscription } from 'rxjs';
import * as fromUser from '../user/state/user.reducer';
import * as userActions from '../user/state/user.actions';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  currentUser: User;
  redirectUrl: string;
  sub: Subscription;
  get isLoggedIn(): boolean {
    return !!this.currentUser;
  }
  get isAdmin(): boolean {
    return this.currentUser ? this.currentUser.isAdmin : false;
  }
  // TODO: Unsubscribe
  constructor(private messageService: MessageService,
              private router: Router,
              private store: Store<fromUser.State>) {
      this.sub = this.store.pipe(select(fromUser.getCurrentUser)).subscribe(
        currentUser => {
          this.currentUser = currentUser;
        }
      );
    }

  login(userName: string, password: string): void {
    if (!userName || !password) {
      this.messageService.addMessage('Please enter your userName and password');
      return;
    }
    if (userName === 'admin') {
      this.currentUser = {
        name: {
          first: 'Mary',
          middle: 'Sue',
          last: 'Hipple'
        },
        address: {
          street1: '2 Sheeps Lane',
          street2: '',
          city: 'Baon Rouget',
          state: 'Louisianna',
          zip: '67890'
        },
        email: 'mary@nocantack.com',
        phone: '123 456-7890',
        isAdmin: true
      };
      this.messageService.addMessage('Admin login');
      this.store.dispatch(new userActions.SetCurrentUser(this.currentUser));
      return;
    }
    this.currentUser = {
      name: {
        first: 'John',
        middle: 'Jay',
        last: 'Dent'
      },
      address: {
        street1: '1 Easy Street',
        street2: '',
        city: 'Los Angeles',
        state: 'California',
        zip: '12345'
      },
      email: 'john@nocantack.com',
      phone: '123 456-7890',
      isAdmin: false
    };
    this.store.dispatch(new userActions.SetCurrentUser(this.currentUser));
    this.messageService.addMessage(`User: ${this.currentUser.name.first} logged in`);
  }

  logout(): void {
    if (this.sub) {
      this.sub.unsubscribe();
    }
    this.currentUser = null;
    this.store.dispatch(new userActions.ClearCurrentUser());
    this.router.navigate(['/home']);
  }
}
