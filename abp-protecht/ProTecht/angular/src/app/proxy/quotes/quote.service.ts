import type {
  GetQuotesInput,
  QuoteCreateDto,
  QuoteDto,
  QuoteExcelDownloadDto,
  QuoteUpdateDto,
  QuoteWithNavigationPropertiesDto,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type {
  AppFileDescriptorDto,
  DownloadTokenResultDto,
  GetFileInput,
  LookupDto,
  LookupRequestDto,
} from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class QuoteService {
  apiName = 'Default';

  create = (input: QuoteCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, QuoteDto>(
      {
        method: 'POST',
        url: '/api/app/quotes',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/app/quotes/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetQuotesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/quotes/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          amount: input.amount,
          vendor: input.vendor,
          personId: input.personId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (quoteIds: string[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/quotes',
        params: { quoteIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, QuoteDto>(
      {
        method: 'GET',
        url: `/api/app/quotes/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/app/quotes/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/quotes/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetQuotesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<QuoteWithNavigationPropertiesDto>>(
      {
        method: 'GET',
        url: '/api/app/quotes',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          amount: input.amount,
          vendor: input.vendor,
          personId: input.personId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (input: QuoteExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/quotes/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          amount: input.amount,
          vendor: input.vendor,
          personId: input.personId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getPersonLookup = (input: LookupRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>(
      {
        method: 'GET',
        url: '/api/app/quotes/person-lookup',
        params: {
          filter: input.filter,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getWithNavigationProperties = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, QuoteWithNavigationPropertiesDto>(
      {
        method: 'GET',
        url: `/api/app/quotes/with-navigation-properties/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: string, input: QuoteUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, QuoteDto>(
      {
        method: 'PUT',
        url: `/api/app/quotes/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/app/quotes/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
