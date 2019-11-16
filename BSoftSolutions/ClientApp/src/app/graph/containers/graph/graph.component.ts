import { Component, OnInit } from '@angular/core';
import { GraphService } from '../../../services/graph.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-graph',
  templateUrl: './graph.component.html',
  styleUrls: ['./graph.component.css']
})
export class GraphComponent implements OnInit {
    graph: Observable<string[]>;
    constructor(private processor: GraphService) { }

    ngOnInit(): void {
        this.graph = this.getGraph();
    }
    errorMessage: string = '';

    getGraph(): Observable<string[]> {
        return this.processor.Graph();
    }

}
