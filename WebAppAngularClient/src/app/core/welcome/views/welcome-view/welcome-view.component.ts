import { Component, OnInit } from '@angular/core';
import { DashboardModel } from '../../../../layouts/models/dashboard/dashboard';

@Component({
  selector: 'app-welcome-view',
  templateUrl: './welcome-view.component.html',
  styleUrl: './welcome-view.component.css',
})
export class WelcomeViewComponent implements OnInit {

  public readonly dashboard: DashboardModel = new DashboardModel();

  ngOnInit(): void {
    /**
     * ToDo: Sustituir por una carga de configuraciones desde una api de configuraciones. 
     * ToDo: Manejar la posibilidad de desconexión y tener una configuración predeterminada.
     */
    let items = new Set<{ src: string, alt: string }>();
    items.add({
      src: 'https://wallpapersmug.com/download/3840x2160/d06c64/starry-space-milky-way-stars.jpg',
      alt: 'Descripcion de imagen'
    });

    items.add({
      src: 'https://wallpapers.com/images/hd/4k-space-glowing-ring-es4tss2e6i1dzfj6.jpg',
      alt: 'Descripcion de imagen'
    });

    items.add({
      src: 'https://wallpapers.com/images/hd/4k-universe-eta-carinae-nebula-2iqpijwfzmw3z4al.jpg',
      alt: 'Descripcion de imagen'
    });

    this.dashboard.FillCarousel(true, 'Previous', 'Next', items);
  }
}
