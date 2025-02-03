import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
    <app-host-dashboard *abpPermission="'ProTecht.Dashboard.Host'"></app-host-dashboard>
  `,
})
export class DashboardComponent {}
