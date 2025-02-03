import type {
  GetPeopleInput,
  PersonCreateDto,
  PersonDto,
  PersonExcelDownloadDto,
  PersonUpdateDto,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AppFileDescriptorDto, DownloadTokenResultDto, GetFileInput } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  apiName = 'Default';

  create = (input: PersonCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PersonDto>(
      {
        method: 'POST',
        url: '/api/app/people',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/app/people/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetPeopleInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/people/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          personId: input.personId,
          name: input.name,
          surname: input.surname,
          contactNumber: input.contactNumber,
          vehicleRegistration: input.vehicleRegistration,
          vehicleType: input.vehicleType,
          ageMin: input.ageMin,
          ageMax: input.ageMax,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (personIds: string[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/people',
        params: { personIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PersonDto>(
      {
        method: 'GET',
        url: `/api/app/people/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/app/people/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/people/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetPeopleInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<PersonDto>>(
      {
        method: 'GET',
        url: '/api/app/people',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          personId: input.personId,
          name: input.name,
          surname: input.surname,
          contactNumber: input.contactNumber,
          vehicleRegistration: input.vehicleRegistration,
          vehicleType: input.vehicleType,
          ageMin: input.ageMin,
          ageMax: input.ageMax,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (input: PersonExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/people/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          personId: input.personId,
          name: input.name,
          surname: input.surname,
          contactNumber: input.contactNumber,
          vehicleRegistration: input.vehicleRegistration,
          vehicleType: input.vehicleType,
          ageMin: input.ageMin,
          ageMax: input.ageMax,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: string, input: PersonUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PersonDto>(
      {
        method: 'PUT',
        url: `/api/app/people/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/app/people/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
