import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddParcelFormComponent } from './add-parcel-form.component';

describe('AddParcelFormComponent', () => {
  let component: AddParcelFormComponent;
  let fixture: ComponentFixture<AddParcelFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddParcelFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddParcelFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
