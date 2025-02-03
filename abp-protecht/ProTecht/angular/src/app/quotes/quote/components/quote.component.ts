import { ChangeDetectionStrategy, Component } from '@angular/core';
import {
  NgbDateAdapter,
  NgbTimeAdapter,
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbTimepickerModule,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { ListService, CoreModule } from '@abp/ng.core';
import { ThemeSharedModule, DateAdapter, TimeAdapter } from '@abp/ng.theme.shared';
import { PageModule } from '@abp/ng.components/page';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';

import { vendorOptions } from '../../../proxy/enum/vendor.enum';
import { QuoteViewService } from '../services/quote.service';
import { QuoteDetailViewService } from '../services/quote-detail.service';
import { QuoteDetailModalComponent } from './quote-detail.component';
import {
  AbstractQuoteComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './quote.abstract.component';

@Component({
  selector: 'app-quote',
  changeDetection: ChangeDetectionStrategy.Default,
  standalone: true,
  imports: [
    ...ChildTabDependencies,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbTimepickerModule,
    NgbDropdownModule,

    NgxValidateCoreModule,

    PageModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    QuoteDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    QuoteViewService,
    QuoteDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './quote.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class QuoteComponent extends AbstractQuoteComponent {}
