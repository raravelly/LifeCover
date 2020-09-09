import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { QuoteDetails } from './quote-details';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {

  constructor() { }
  getOccupations(): Observable<string[]>{
    return of(["Occ1", "Occ2"]);
  }

  getQuote(details: QuoteDetails): Observable<number>{
    return of(1.2);
  }
}
