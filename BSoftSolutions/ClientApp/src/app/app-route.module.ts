import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'
import { Routes, RouterModule } from '@angular/router';

import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from 'src/api-authorization/login/login.component';
import { ResumeComponent } from './resume/resume.component';
import { GeoProcessingComponent } from './geoprocessing/geoprocessing.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'geo', component: GeoProcessingComponent },
    { path: 'resume', component: ResumeComponent, canActivate: [AuthorizeGuard] },
    { path: 'login', component: LoginComponent },
    { path: '**', component: PageNotFoundComponent }
];


@NgModule({
  declarations: [
        HomeComponent,
        ResumeComponent,
        GeoProcessingComponent,
        PageNotFoundComponent
    ],
  imports: [
      CommonModule,
      FormsModule,
      RouterModule.forRoot(routes),
      ApiAuthorizationModule
    ],
    exports: [
        CommonModule,
        FormsModule,
        RouterModule,
        ApiAuthorizationModule
    ]
})
export class AppRouteModule { }
