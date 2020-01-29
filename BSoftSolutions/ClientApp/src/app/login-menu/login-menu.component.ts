import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login-menu',
  templateUrl: './login-menu.component.html',
  styleUrls: ['./login-menu.component.css']
})
export class LoginMenuComponent implements OnInit {
  public isAuthenticated: Observable<boolean>;
  public userName: Observable<any>;

  constructor(private authorizeService: AuthService) { }

  ngOnInit() {
    this.isAuthenticated = this.authorizeService.isAuthenticated$;
    this.userName = this.authorizeService.getUser$();
  }
}
