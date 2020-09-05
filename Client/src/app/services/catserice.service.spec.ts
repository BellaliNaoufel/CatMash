import { TestBed } from '@angular/core/testing';

import { CatsericeService } from './catserice.service';

describe('CatsericeService', () => {
  let service: CatsericeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CatsericeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
