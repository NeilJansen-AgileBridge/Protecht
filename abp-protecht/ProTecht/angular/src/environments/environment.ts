 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44332/',
  redirectUri: baseUrl,
  clientId: 'ProTecht_App',
  responseType: 'code',
  scope: 'offline_access ProTecht',
  requireHttps: true,
  impersonation: {
    userImpersonation: true,
  }
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'ProTecht',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44332',
      rootNamespace: 'ProTecht',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
