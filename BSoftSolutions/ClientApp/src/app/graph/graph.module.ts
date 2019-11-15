import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GraphComponent } from './containers/graph/graph.component'

@NgModule({
  declarations: [GraphComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
          { path: 'graph', component: GraphComponent },
    ])
  ]
})

export class GraphModule { }
