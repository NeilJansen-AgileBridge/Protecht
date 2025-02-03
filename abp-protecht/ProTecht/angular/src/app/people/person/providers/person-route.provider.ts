import { APP_INITIALIZER, inject } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { PERSON_BASE_ROUTES } from './person-base.routes';

export const PEOPLE_PERSON_ROUTE_PROVIDER = [
  {
    provide: APP_INITIALIZER,
    multi: true,
    useFactory: configureRoutes,
  },
];

function configureRoutes() {
  const routesService = inject(RoutesService);

  return () => {
    const routes: ABP.Route[] = [...PERSON_BASE_ROUTES];
    routesService.add(routes);
  };
}
