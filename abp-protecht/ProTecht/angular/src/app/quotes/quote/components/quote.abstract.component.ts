import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import { vendorOptions } from '../../../proxy/enum/vendor.enum';
import type { QuoteWithNavigationPropertiesDto } from '../../../proxy/quotes/models';
import { QuoteViewService } from '../services/quote.service';
import { QuoteDetailViewService } from '../services/quote-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractQuoteComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(QuoteViewService);
  public readonly serviceDetail = inject(QuoteDetailViewService);
  protected title = '::Quotes';

  vendorOptions = vendorOptions;

  ngOnInit() {
    this.service.hookToQuery();
  }

  clearFilters() {
    this.service.clearFilters();
  }

  showForm() {
    this.serviceDetail.showForm();
  }

  create() {
    this.serviceDetail.selected = undefined;
    this.serviceDetail.showForm();
  }

  update(record: QuoteWithNavigationPropertiesDto) {
    this.serviceDetail.update(record);
  }

  delete(record: QuoteWithNavigationPropertiesDto) {
    this.service.delete(record);
  }

  exportToExcel() {
    this.service.exportToExcel();
  }
}
