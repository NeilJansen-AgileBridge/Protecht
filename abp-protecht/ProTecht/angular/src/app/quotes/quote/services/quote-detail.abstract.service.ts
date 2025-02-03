import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import { vendorOptions } from '../../../proxy/enum/vendor.enum';
import type { QuoteWithNavigationPropertiesDto } from '../../../proxy/quotes/models';
import { QuoteService } from '../../../proxy/quotes/quote.service';

export abstract class AbstractQuoteDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);

  public readonly proxyService = inject(QuoteService);
  public readonly list = inject(ListService);

  public readonly getPersonLookup = this.proxyService.getPersonLookup;

  vendorOptions = vendorOptions;

  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  protected createRequest() {
    const formValues = {
      ...this.form.value,
    };

    if (this.selected) {
      return this.proxyService.update(this.selected.quote.id, {
        ...formValues,
        concurrencyStamp: this.selected.quote.concurrencyStamp,
      });
    }

    return this.proxyService.create(formValues);
  }

  buildForm() {
    const { amount, vendor, personId } = this.selected?.quote || {};

    this.form = this.fb.group({
      amount: [amount ?? null, []],
      vendor: [vendor ?? null, [Validators.required]],
      personId: [personId ?? null, []],
    });
  }

  showForm() {
    this.buildForm();
    this.isVisible = true;
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: QuoteWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  hideForm() {
    this.isVisible = false;
  }

  submitForm() {
    if (this.form.invalid) return;

    this.isBusy = true;

    const request = this.createRequest().pipe(
      finalize(() => (this.isBusy = false)),
      tap(() => this.hideForm()),
    );

    request.subscribe(this.list.get);
  }

  changeVisible($event: boolean) {
    this.isVisible = $event;
  }
}
