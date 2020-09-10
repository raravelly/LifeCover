import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { isDevMode } from '@angular/core';

import { QuoteDetails } from './quote-details';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {

  apiBaseUrl = isDevMode() ? "https://localhost:5001/" : "/";
  constructor(private http: HttpClient) { }
  getOccupations(): Observable<string[]>{
    var result = this.http.get<string[]>(this.apiBaseUrl + 'api/occupations');
    console.log(result);
    return result;
  }

  getQuote(details: QuoteDetails): Observable<number>{
    var result = this.http.post<number>(this.apiBaseUrl + 'api/premium', details);
    console.log(result);
    return result;
  }
}
