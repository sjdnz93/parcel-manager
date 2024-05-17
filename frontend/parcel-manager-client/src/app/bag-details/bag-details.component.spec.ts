import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BagDetailsComponent } from './bag-details.component';

describe('BagDetailsComponent', () => {
  let component: BagDetailsComponent;
  let fixture: ComponentFixture<BagDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BagDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BagDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
