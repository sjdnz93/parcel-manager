import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBagFormComponent } from './add-bag-form.component';

describe('AddBagFormComponent', () => {
  let component: AddBagFormComponent;
  let fixture: ComponentFixture<AddBagFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddBagFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddBagFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
