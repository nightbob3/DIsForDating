import { TestBed } from '@angular/core/testing';

import { TonyIsGayService } from './tony-is-gay.service';

describe('TonyIsGayService', () => {
  let service: TonyIsGayService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TonyIsGayService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
