import { createFeatureSelector, createSelector } from '@ngrx/store';
import { Movie } from '../../models/movie';
import { MovieActionTypes, MovieActions } from './movie.actions';

export interface MovieState {
    list: Movie[];
    error: string;
}

const initialState: MovieState = {
    list: [],
    error: ''
};

const getMovieFeatureState = createFeatureSelector<MovieState>('movie');

export const getMovies = createSelector(
    getMovieFeatureState,
    state => state.list
);

export const getError = createSelector(
  getMovieFeatureState,
  state => state.error
);

export function movieReducer(state = initialState, action: MovieActions): MovieState {
    switch (action.type) {
      case MovieActionTypes.LoadMoviesSuccess:
        return {
          ...state,
          list: action.payload,
          error: ''
        };
      case MovieActionTypes.LoadMoviesFail:
        return {
          ...state,
          list: [],
          error: action.payload
        };
      default:
        return state;
    }
}
