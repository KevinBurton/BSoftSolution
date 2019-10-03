import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { ICoordinate } from "./coordinate";
import { Observable, ObservableInput, throwError } from "rxjs";
import { filter, map, tap, catchError } from "rxjs/operators";

import { tamugeocode } from "./tamugeocode";

@Injectable({
    providedIn: 'root'
})
export class GeoProcessor {
    constructor(private http: HttpClient) {

    }
    public Geocode(_locationDescription: string): Observable<ICoordinate[]> {
        const TAMMapsKey: string = '22f8bcc7f57b47d38700fbfa2a759a2e';
        let regex: RegExp = /([A-Za-z0-9 -]+)\s*,\s*([A-Za-z]+)/g;
        let m: RegExpExecArray = regex.exec(_locationDescription);
        if (!m || m.length < 3) {
            return null;
        }
        let city:string = m[1];
        let region:string = m[2];

        let url: string = `https://geoservices.tamu.edu/Services/Geocode/WebService/GeocoderWebServiceHttpNonParsed_V04_01.aspx?city=${m[1]}&state=${m[2]}&apikey=${TAMMapsKey}&format=json&notStore=false&version=4.01`;
        return this.http.get<tamugeocode>(url).pipe(
            filter(data => {
                return data.FeatureMatchingResultType == 'Success';
            }),
            map(data => data.OutputGeocodes.map(o => {
                let r = new ICoordinate();
                r.latitude = o.OutputGeocode.Latitude;
                r.longitude = o.OutputGeocode.Longitude;
                return r;
            })),
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