import { Component } from '@angular/core';

@Component({
    selector: 'app-geoprocessing',
    templateUrl: './geoprocessing.component.html'
})
export class GeoProcessingComponent {
    geocodeInput: string = '';
    processGeocodeInput(): void {
        console.log(`Geocode input: ${this.geocodeInput}`);
    }
}