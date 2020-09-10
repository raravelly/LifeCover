import { Component, OnInit } from '@angular/core';
import { QuoteService } from './quote.service';
import { QuoteDetails } from './quote-details';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Life Cover';

  occupations: string[] = [];

  premium: number = 0;

  errors: string[] = [];

  constructor(private quoteService: QuoteService){}

  ngOnInit(): void {
    this.getOccupations();
  }

  getOccupations(): void{
    this.quoteService.getOccupations()
      .subscribe(occupations => this.occupations = occupations);
  }

  onGetQuote(details: QuoteDetails){
    console.log('app-component: quote:', JSON.stringify(details));
    this.errors = [];
    this.quoteService.getQuote(details)
    .subscribe(p => 
      {
        this.premium = p
      },
      err => {
        this.errors = err.error;
        console.log('errors: ', this.errors);
      });
  }
}
