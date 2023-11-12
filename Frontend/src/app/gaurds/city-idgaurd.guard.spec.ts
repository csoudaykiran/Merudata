import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { cityIDGaurdGuard } from './city-idgaurd.guard';

describe('cityIDGaurdGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => cityIDGaurdGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
