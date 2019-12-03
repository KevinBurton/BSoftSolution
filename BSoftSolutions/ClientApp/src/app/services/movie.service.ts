import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, ObservableInput, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

import { Movie } from '../models/movie';

@Injectable({
    providedIn: 'root'
})
export class MovieService {
    constructor(private http: HttpClient) {

    }
    public DatabaseList(): Observable<string[]> {
        const url = '/Movie/DatabaseList';
        return this.http.get<any>(url).pipe(
            tap((data) => console.log(`Database List: ${data.length}`)),
            catchError(this.handleError)
        );
    }
    public getMovies(): Observable<Movie[]> {
        const url = '/Movie/MovieList';
        return this.http.get<Movie[]>(url).pipe(
            tap((data) => {
                console.log(`Movie List: ${data.length}`);
            }),
            catchError(this.handleError)
        );
    }
    public actorMovieDictionary(): Observable<any> {
        const url = '/Movie/ActorMovieDictionary';
        return this.http.get<any>(url).pipe(
            tap((data) => {
                console.log(`Actor Movie Dictionary: ${Object.keys(data).length}`);
            }),
            catchError(this.handleError)
        );
    }
    private handleError(err: HttpErrorResponse): ObservableInput<any> {
        let errorMessage = '';
        if (err.error instanceof ErrorEvent) {
            errorMessage = `An error occurred: ${err.error.message}`;
        } else {
            errorMessage = `Server returned code ${err.status}, error message is ${err.message}`;
        }
        console.error(errorMessage);
        return throwError(errorMessage);
    }
}
