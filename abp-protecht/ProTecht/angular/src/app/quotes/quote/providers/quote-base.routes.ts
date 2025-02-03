import { ABP, eLayoutType } from '@abp/ng.core';

export const QUOTE_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/quotes',
    iconClass: 'fas fa-file-alt',
    name: '::Menu:Quotes',
    layout: eLayoutType.application,
    requiredPolicy: 'ProTecht.Quotes',
    breadcrumbText: '::Quotes',
  },
];
