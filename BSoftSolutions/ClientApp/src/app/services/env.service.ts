import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EnvService {

  // The values that are defined here are the default values that can
  // be overridden by env.js

  // API base url
  public apiBase = 'http://localhost:5000';

  constructor() {
  }

}
