import { Component } from '@angular/core';
import { GeoProcessor } from '../shared/geoprocessor.service';

@Component({
    selector: 'app-geoprocessing',
    templateUrl: './geoprocessing.component.html'
})
export class GeoProcessingComponent {
    constructor(private processor: GeoProcessor) {

    }
    geocodeInput: string = '';
    processGeocodeInput(): void {
        console.log(`Geocode input: ${this.geocodeInput}`);
    }
}