import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {NgForm} from '@angular/forms';
import { QuoteDetails } from '../quote-details';

@Component({
  selector: 'app-quote',
  templateUrl: './quote.component.html',
  styleUrls: ['./quote.component.css']
})
export class QuoteComponent{

  @Input() occupations: string[];
  @Output() quote = new EventEmitter<QuoteDetails>();
  model = <QuoteDetails>{};
  onSubmit(myform: NgForm){
    if(myform.valid){
      console.log('valid');
      this.requestQuote(this.model);
    }
    else{
      console.log('not valid')
    }
  }
  requestQuote(details: QuoteDetails){
    console.log('emitting quote request');
    this.quote.emit(details);
  }
}

