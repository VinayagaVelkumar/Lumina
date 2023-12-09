import { TestBed } from '@angular/core/testing';

import { SlmsService } from './slms.service';

describe('SlmsService', () => {
  let service: SlmsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SlmsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
