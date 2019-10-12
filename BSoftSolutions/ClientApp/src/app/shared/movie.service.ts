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
    public DBList(): Observable<string[]> {
        let url: string = '/Movie/DBList';
        return this.http.get<any>(url).pipe(
            tap((data) => console.log('All: ' + JSON.stringify(data))),
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