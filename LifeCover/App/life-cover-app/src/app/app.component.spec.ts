import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { QuoteService } from './quote.service';
import { QuoteDetails } from './quote-details';
import { of } from 'rxjs';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  const testOccupations = ['oc1','oc2'];
  beforeEach(async(() => {
    const fakeService = jasmine.createSpyObj('QuoteService',['getOccupations','getQuote']);

    var getOccupationsSpy = fakeService.getOccupations.and.returnValue(of(testOccupations));
    var getQuoteSpy = fakeService.getQuote.and.returnValue(of(1));
    TestBed.configureTestingModule({
      declarations: [
        AppComponent
      ],
      providers:[{provide: QuoteService, useValue:fakeService}]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
  });


  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it('should get occupations', () => {
      component.ngOnInit();
      expect(component.occupations).toBe(testOccupations)
  });

  it('should get quote', () => {
    var detail: QuoteDetails = {
      name:'abc', 
      age: 1, 
      occupation: 'oc', 
      sumInsured: 2, 
      dateOfBirth: new Date
    };
    component.onGetQuote(detail);
    expect(component.premium).toBe(1);
});
});
