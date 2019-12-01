import { Component } from '@angular/core';
import { MovieService } from '../../../services/movie.service';
import { Movie } from "../../../models/movie";

@Component({
    selector: 'app-movie',
    templateUrl: './movie.component.html'
})
export class MovieComponent {
    constructor(private processor: MovieService) {

    }
    errorMessage: string = '';
    geocodeInput: string = '';
    movieList: Movie[] = [];
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
        this.processor.getMovies().
            subscribe({
                next: loc => {
                    this.movieList = [...loc];
                },
                error: err => this.errorMessage = err
            });
    }
    getActorMovieDictionary(): void {
        this.processor.actorMovieDictionary().
            subscribe({
                next: loc => {
                    this.movieCastDictionary = loc;
                },
                error: err => this.errorMessage = err
            });
    }
}
