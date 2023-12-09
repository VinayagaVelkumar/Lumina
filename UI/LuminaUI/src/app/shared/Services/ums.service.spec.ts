import { TestBed } from '@angular/core/testing';

import { UmsService } from './ums.service';

describe('UmsService', () => {
  let service: UmsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UmsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
