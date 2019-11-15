import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable, ObservableInput, throwError } from "rxjs";
import { tap, catchError } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class GraphService {

    constructor(private http: HttpClient) { }

    public Graph(): Observable<string[]> {
        let url: string = '/api/graph';
        return this.http.get<Map<string, string[]>>(url).pipe(
            tap((data) => console.log(`Graph List: ${data.keys}`)),
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
