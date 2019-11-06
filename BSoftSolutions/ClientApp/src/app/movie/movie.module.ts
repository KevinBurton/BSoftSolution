import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MovieComponent } from './containers/movie/movie.component';
import { MovieListComponent } from './components/movie-list/movie-list.component';

@NgModule({
  declarations: [
    MovieComponent,
    MovieListComponent
  ],
  imports: [
      CommonModule,
      RouterModule.forChild([
          { path: 'movie', component: MovieComponent },
     ])
  ]
})
export class MovieModule { }
