import { APP_INITIALIZER, inject } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { QUOTE_BASE_ROUTES } from './quote-base.routes';

export const QUOTES_QUOTE_ROUTE_PROVIDER = [
  {
    provide: APP_INITIALIZER,
    multi: true,
    useFactory: configureRoutes,
  },
];

function configureRoutes() {
  const routesService = inject(RoutesService);

  return () => {
    const routes: ABP.Route[] = [...QUOTE_BASE_ROUTES];
    routesService.add(routes);
  };
}
