import { ABP, eLayoutType } from '@abp/ng.core';

export const PERSON_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/people',
    iconClass: 'fas fa-file-alt',
    name: '::Menu:People',
    layout: eLayoutType.application,
    requiredPolicy: 'ProTecht.People',
    breadcrumbText: '::People',
  },
];
