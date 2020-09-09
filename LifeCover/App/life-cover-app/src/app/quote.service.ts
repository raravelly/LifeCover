import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { QuoteDetails } from './quote-details';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {

  apiBaseUrl = "https://localhost:5001/";
  constructor(private http: HttpClient) { }
  getOccupations(): Observable<string[]>{
    return of(["Occ1", "Occ2"]);
  }

  getQuote(details: QuoteDetails): Observable<number>{
    //return of(1.2);
    var result = this.http.post<number>(this.apiBaseUrl + 'api/premium', details);
    console.log(result);
    return result;
  }
}
