import { TestBed } from '@angular/core/testing';

import { LetterBagService } from './letter-bag.service';

describe('LetterBagService', () => {
  let service: LetterBagService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LetterBagService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
