import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './auth/auth.guard';

import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { LoginComponent } from './login/login.component';
import { ResumeComponent } from './resume/resume.component';
import { GeoProcessingComponent } from './geoprocessing/geoprocessing.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'geo', component: GeoProcessingComponent },
    { path: 'resume', component: ResumeComponent, canActivate: [AuthGuard] },
    { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: '**', component: PageNotFoundComponent }
];


@NgModule({
  declarations: [
      HomeComponent,
      ProfileComponent,
      ResumeComponent,
      GeoProcessingComponent,
      PageNotFoundComponent
    ],
  imports: [
      CommonModule,
      FormsModule,
      RouterModule.forRoot(routes)
    ],
    exports: [
        CommonModule,
        FormsModule,
        RouterModule
    ]
})
export class AppRouteModule { }
