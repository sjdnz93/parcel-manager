import { TestBed } from '@angular/core/testing';

import { ParcelBagService } from './parcel-bag.service';

describe('ParcelBagService', () => {
  let service: ParcelBagService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ParcelBagService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
