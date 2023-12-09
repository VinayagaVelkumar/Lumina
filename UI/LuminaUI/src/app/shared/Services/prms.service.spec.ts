import { TestBed } from '@angular/core/testing';

import { PrmsService } from './prms.service';

describe('PrmsService', () => {
  let service: PrmsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PrmsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
