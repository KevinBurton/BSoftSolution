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
    getDBList(): void {
        this.processor.DBList().
            subscribe({
                next: loc => {
                    loc.forEach(l => console.log(`DB Name:${l}`));
                },
                error: err => this.errorMessage = err
            });
    }
}