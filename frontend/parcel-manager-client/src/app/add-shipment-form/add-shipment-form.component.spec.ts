import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddShipmentFormComponent } from './add-shipment-form.component';

describe('AddShipmentFormComponent', () => {
  let component: AddShipmentFormComponent;
  let fixture: ComponentFixture<AddShipmentFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddShipmentFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddShipmentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
