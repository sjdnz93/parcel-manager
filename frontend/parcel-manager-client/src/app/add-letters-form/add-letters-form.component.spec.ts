import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLettersFormComponent } from './add-letters-form.component';

describe('AddLettersFormComponent', () => {
  let component: AddLettersFormComponent;
  let fixture: ComponentFixture<AddLettersFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddLettersFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddLettersFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
