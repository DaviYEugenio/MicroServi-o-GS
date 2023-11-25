import { Component, NgModule } from '@angular/core';
import * as bootstrap from 'bootstrap';




@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ODS3';
  currentNavItem?: string;
  public loading = false;
  ngOnInit() {
  }
}
