import { trigger, transition, query, style, animate } from '@angular/animations';

/**
 * Animation trigger for route transitions.
 * This animation handles the slide-in and fade effects for route changes.
 */
export const slideInAnimation =
  trigger('routeAnimations', [
    transition('* <=> *', [
      /**
       * Styles for entering and leaving elements.
       * Sets position, width, and height to ensure proper animation.
       */
      query(':enter, :leave', [
        style({
          position: 'absolute',
          width: '100%',
          height: '100%'
        })
      ], { optional: true }),
      
      /**
       * Animation for entering elements.
       * Initially sets opacity to 0, then animates to 50% opacity.
       */
      query(':enter', [
        style({ opacity: 0 }),
        animate('0.25s cubic-bezier(.25, 1, .30, 1)', style({ opacity: 50 }))
      ], { optional: true }),
      
      /**
       * Animation for leaving elements.
       * Starts with 50% opacity, then animates to 0 opacity.
       */
      query(':leave', [
        style({ opacity: 50 }),
        animate('0.5s cubic-bezier(.25, 1, .30, 1)', style({ opacity: 0 }))
      ], { optional: true })
    ])
  ]);
