import { Action } from '@ngrx/store';
import { Movie } from '../../models/movie';

export enum MovieActionTypes {
    LoadMovies = '[Movie] Initiate load of movies from DB',
    LoadMoviesSuccess = '[Movie] Successfull load of movies',
    LoadMoviesFail = '[Movie] Load movies failed'
}

export class LoadMovies implements Action {
  readonly type = MovieActionTypes.LoadMovies;
}

export class LoadMoviesSuccess implements Action {
  readonly type = MovieActionTypes.LoadMoviesSuccess;
  constructor(public payload: Movie[]) {}
}
export class LoadMoviesFail implements Action {
  readonly type = MovieActionTypes.LoadMoviesFail;
  constructor(public payload: string) {}
}

export type MovieActions = LoadMovies |
                             LoadMoviesSuccess |
                             LoadMoviesFail;
