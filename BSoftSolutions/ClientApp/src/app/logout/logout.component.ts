import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { BehaviorSubject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';

// The main responsibility of this component is to handle the user's logout process.
// This is the starting point for the logout process, which is usually initiated when a
// user clicks on the logout button on the LoginMenu component.
@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {
  public message = new BehaviorSubject<string>(null);

  constructor(
    private authorizeService: AuthService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }

  async ngOnInit() {
    const action = this.activatedRoute.snapshot.url[1];
    switch (action.path) {
    }
  }
  private async logout(returnUrl: string): Promise<void> {
    const isauthenticated = await this.authorizeService.isAuthenticated$.pipe(
      take(1)
    ).toPromise();
    if (isauthenticated) {
      this.authorizeService.logout();
    }
  }
  private async navigateToReturnUrl(returnUrl: string) {
    await this.router.navigateByUrl(returnUrl, {
      replaceUrl: true
    });
  }
}
