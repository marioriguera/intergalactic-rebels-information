import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { slideInAnimation } from './shared/animations/animations';

/**
 * Root component of the application.
 * This component sets up the application shell and handles route animations.
 */
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'], // Fixed typo: 'styleUrl' to 'styleUrls'
  animations: [slideInAnimation]
})
export class AppComponent {
  title = 'IRI.Clients.Web';

  /**
   * Prepares the route for animations.
   * This method determines which animation to apply based on the activated route's data.
   * 
   * @param outlet The RouterOutlet that contains the currently activated route.
   * @returns The animation data if available, otherwise null.
   */
  prepareRoute(outlet: RouterOutlet) {
    return outlet && outlet.activatedRouteData && outlet.activatedRouteData['animation'];
  }
}
