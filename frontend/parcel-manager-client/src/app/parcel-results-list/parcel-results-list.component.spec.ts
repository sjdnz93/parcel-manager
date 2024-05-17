import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParcelResultsListComponent } from './parcel-results-list.component';

describe('ParcelResultsListComponent', () => {
  let component: ParcelResultsListComponent;
  let fixture: ComponentFixture<ParcelResultsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ParcelResultsListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ParcelResultsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
