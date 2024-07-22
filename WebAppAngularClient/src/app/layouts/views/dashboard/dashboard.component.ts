import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardModel } from '../../models/dashboard/dashboard';

/**
 * Component responsible for displaying the dashboard.
 * This component handles the initialization and navigation logic for the dashboard.
 */
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'] // Fixed typo: 'styleUrl' to 'styleUrls'
})
export class DashboardComponent implements OnInit {

  /**
   * Constructor for DashboardComponent.
   * @param _router Angular Router service to handle navigation.
   */
  constructor(private readonly _router: Router) { }

  @Input() dashboardModelVar: DashboardModel = new DashboardModel();
  showCarousel: boolean = true;
  previousButtonLabel: string = 'Previous';
  nextButtonLabel: string = 'Next';

  /**
   * Lifecycle hook that is called after data-bound properties of a directive are initialized.
   * In this implementation, it navigates to the home route.
   */
  ngOnInit(): void {
    this._router.navigate(['']);
  }
}
