import { Component } from '@angular/core';
import { MovieProcessor } from '../shared/movie.service';

@Component({
    selector: 'app-movie',
    templateUrl: './movie.component.html'
})
export class MovieComponent {
    constructor(private processor: MovieProcessor) {

    }
    errorMessage: string = '';
    geocodeInput: string = '';
    movieList: string[] = [];
    databaseList: string[] = [];
    movieCastDictionary: any = {};
    getDatabaseList(): void {
        this.processor.DatabaseList().
            subscribe({
                next: loc => {
                    this.databaseList = [...loc];
                },
                error: err => this.errorMessage = err
            });
    }
    getMovieList(): void {
        this.processor.MovieList().
            subscribe({
                next: loc => {
                    this.movieList = [...loc];
                },
                error: err => this.errorMessage = err
            });
    }
    getMovieCastDictionary(): void {
        this.processor.MovieCastDictionary().
            subscribe({
                next: loc => {
                    this.movieCastDictionary = loc;
                },
                error: err => this.errorMessage = err
            });
    }
}