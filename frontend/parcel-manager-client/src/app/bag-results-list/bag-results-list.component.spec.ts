import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BagResultsListComponent } from './bag-results-list.component';

describe('BagResultsListComponent', () => {
  let component: BagResultsListComponent;
  let fixture: ComponentFixture<BagResultsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BagResultsListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BagResultsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
