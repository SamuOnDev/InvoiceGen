import { TestBed } from '@angular/core/testing';

import { InvoiceContentService } from './invoice-content.service';

describe('InvoiceContentService', () => {
  let service: InvoiceContentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InvoiceContentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
