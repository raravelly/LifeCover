import { async, ComponentFixture, ComponentFixtureAutoDetect, TestBed } from '@angular/core/testing';

import { QuoteComponent } from './quote.component';
import {NgForm, FormsModule} from '@angular/forms';
import { QuoteDetails } from '../quote-details';

describe('QuoteComponent', () => {
  let component: QuoteComponent;
  let fixture: ComponentFixture<QuoteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule],
      declarations: [ QuoteComponent ],
      providers: [
        { provide: ComponentFixtureAutoDetect, useValue: true }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuoteComponent);
    component = fixture.componentInstance;
    //fixture.detectChanges();
    component.occupations = ['oc1', 'oc2'];
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should emit when form is valid', () =>{
    const hostElement = fixture.debugElement.nativeElement;
    const nameInput: HTMLInputElement = hostElement.querySelector('#name');
    const ageInput: HTMLInputElement = hostElement.querySelector('#age');
    const occupationInput: HTMLInputElement = hostElement.querySelector('#occupation');
    const sunInsuredInput: HTMLInputElement = hostElement.querySelector('#sumInsured');
    nameInput.value = "test name";
    ageInput.value = "1";
    occupationInput.value = "oc1";
    sunInsuredInput.value = "2";

    nameInput.dispatchEvent(new Event('input'));
    ageInput.dispatchEvent(new Event('input'));
    sunInsuredInput.dispatchEvent(new Event('input'));

    const button: HTMLButtonElement = hostElement.querySelector('button')
    spyOn(component.quote, 'emit');
    
    button.click();
    
    expect(component.quote.emit).toHaveBeenCalled();

  })
});
