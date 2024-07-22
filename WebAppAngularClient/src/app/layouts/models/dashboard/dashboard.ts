import { Carousel } from "./carousel";

export class DashboardModel {

    /**
     * The carousel for a dashboard.
     */
    public readonly Carousel: Carousel = new Carousel();

    public FillCarousel(
        canShowTheCarousel: boolean,
        previousButtonLabel: string,
        nextButtonLabel: string,
        carouselItems: Set<{ src: string, alt: string }> | { src: string, alt: string }
    ): void {
        this.Carousel.CanShowTheCarousel = canShowTheCarousel;
        this.Carousel.AddNewItemsToCarousel(carouselItems);
    }
}
