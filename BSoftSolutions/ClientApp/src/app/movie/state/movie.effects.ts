import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { mergeMap, map, catchError } from 'rxjs/operators';

import { MovieService } from '../../services/movie.service';

/* NgRx */
import { Action } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import * as movieActions from './movie.actions';

@Injectable()
export class ProductEffects {

  constructor(private movieService: MovieService,
              private actions$: Actions) { }

  @Effect()
  loadMovies$: Observable<Action> = this.actions$.pipe(
    ofType(movieActions.MovieActionTypes.LoadMovies),
    mergeMap(action =>
      this.movieService.getMovies().pipe(
        map(movies => (new movieActions.LoadMoviesSuccess(movies))),
        catchError(err => of(new movieActions.LoadMoviesFail(err)))
      )
    )
  );

}
