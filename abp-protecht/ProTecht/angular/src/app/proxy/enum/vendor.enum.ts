import { mapEnumToOptions } from '@abp/ng.core';

export enum Vendor {
  InsureIt = 1,
  VehiCover = 2,
}

export const vendorOptions = mapEnumToOptions(Vendor);
