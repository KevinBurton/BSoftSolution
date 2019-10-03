import { Component } from '@angular/core';
import { GeoProcessor } from '../shared/geoprocessor.service';
import { ICoordinate } from '../shared/coordinate';

@Component({
    selector: 'app-geoprocessing',
    templateUrl: './geoprocessing.component.html'
})
export class GeoProcessingComponent {
    constructor(private processor: GeoProcessor) {

    }
    location: ICoordinate[];
    errorMessage: string = '';
    geocodeInput: string = '';
    processGeocodeInput(): void {
        console.log(`Geocode input: ${this.geocodeInput}`);
        this.processor.Geocode(this.geocodeInput).
            subscribe({
                next: loc => {
                    this.location = loc;
                    console.log(`Latitude:${loc[0].latitude} Longitude:${loc[0].longitude}`);
                },
                error: err => this.errorMessage = err
            });
    }
}