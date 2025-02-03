import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetPeopleInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  personId?: string;
  name?: string;
  surname?: string;
  contactNumber?: string;
  vehicleRegistration?: string;
  vehicleType?: string;
  ageMin?: any;
  ageMax?: any;
}

export interface PersonCreateDto {
  personId?: string;
  name: string;
  surname: string;
  contactNumber?: string;
  vehicleRegistration?: string;
  vehicleType?: string;
  age: any;
}

export interface PersonDto extends FullAuditedEntityDto<string> {
  personId?: string;
  name: string;
  surname: string;
  contactNumber?: string;
  vehicleRegistration?: string;
  vehicleType?: string;
  age: any;
  concurrencyStamp?: string;
}

export interface PersonExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  personId?: string;
  name?: string;
  surname?: string;
  contactNumber?: string;
  vehicleRegistration?: string;
  vehicleType?: string;
  ageMin?: any;
  ageMax?: any;
}

export interface PersonUpdateDto {
  personId?: string;
  name: string;
  surname: string;
  contactNumber?: string;
  vehicleRegistration?: string;
  vehicleType?: string;
  age: any;
  concurrencyStamp?: string;
}
