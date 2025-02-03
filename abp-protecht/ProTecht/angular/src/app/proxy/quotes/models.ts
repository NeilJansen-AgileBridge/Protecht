import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { Vendor } from '../enum/vendor.enum';
import type { PersonDto } from '../people/models';

export interface GetQuotesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  amount?: string;
  vendor?: Vendor;
  personId?: string;
}

export interface QuoteCreateDto {
  amount?: string;
  vendor: Vendor;
  personId?: string;
}

export interface QuoteDto extends FullAuditedEntityDto<string> {
  amount?: string;
  vendor: Vendor;
  personId?: string;
  concurrencyStamp?: string;
}

export interface QuoteExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  amount?: string;
  vendor?: Vendor;
  personId?: string;
}

export interface QuoteUpdateDto {
  amount?: string;
  vendor: Vendor;
  personId?: string;
  concurrencyStamp?: string;
}

export interface QuoteWithNavigationPropertiesDto {
  quote: QuoteDto;
  person: PersonDto;
}
