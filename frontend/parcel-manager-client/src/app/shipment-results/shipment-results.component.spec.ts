import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipmentResultsComponent } from './shipment-results.component';

describe('ShipmentResultsComponent', () => {
  let component: ShipmentResultsComponent;
  let fixture: ComponentFixture<ShipmentResultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShipmentResultsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ShipmentResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
