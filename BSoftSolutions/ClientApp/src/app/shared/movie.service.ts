import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable, ObservableInput, throwError } from "rxjs";
import { tap, catchError } from "rxjs/operators";

@Injectable({
    providedIn: 'root'
})
export class MovieProcessor {
    constructor(private http: HttpClient) {

    }
    public DbList(): Observable<string[]> {
        let url: string = '/Movie/DBList';
        return this.http.get<any>(url).pipe(
            tap((data) => console.log('DB List All: ' + JSON.stringify(data))),
            catchError(this.handleError)
        );
    }
    public MovieList(): Observable<string[]> {
        let url: string = '/Movie/MovieList';
        return this.http.get<string[]>(url).pipe(
            tap((data) => console.log(`Movie List: ${data.length}`)),
            catchError(this.handleError)
        );
    }
    private handleError(err: HttpErrorResponse): ObservableInput<any> {
        let errorMessage: string = '';
        if (err.error instanceof ErrorEvent) {
            errorMessage = `An error occurred: ${err.error.message}`;
        } else {
            errorMessage = `Server returned code ${err.status}, error message is ${err.message}`;
        }
        console.error(errorMessage);
        return throwError(errorMessage);
    }
}