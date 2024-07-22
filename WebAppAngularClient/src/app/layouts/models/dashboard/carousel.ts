export class Carousel {

    /**
     * Indicates whether the carousel should be shown.
     */
    public CanShowTheCarousel: boolean = false;

    /**
     * Label for the previous button in the carousel.
     */
    public PreviousButtonLabel: string = 'Previous';

    /**
     * Label for the next button in the carousel.
     */
    public NextButtonLabel: string = 'Next';

    /**
     * Set collection of carousel items.
     */
    public CarouselCollection: Set<CarouselItemModel> = new Set();

    /**
     * Try adding a new element to the carousel.
     * @param carouselItems A collection o a object to add items in carousel collection.
     * @argument src on a @param carouselItems its a the image source path.
     * @argument alt on a @param carouselItems its a text describing the image.
     * @returns True if the item was added to collection, otherwise return false.
     */
    public AddNewItemsToCarousel(
        carouselItems: Set<{ src: string, alt: string }> | { src: string, alt: string }
    ): boolean {

        if (!this.CanShowTheCarousel) return false;

        this.ClearCarouselItems();

        if (carouselItems instanceof Set) {
            carouselItems.forEach(value => this.CarouselCollection.add(new CarouselItemModel(value.src, value.alt)));
            return true;
        }

        this.CarouselCollection.add(new CarouselItemModel(carouselItems.src, carouselItems.alt));

        return true;
    }

    /**
     * Clear all items of @property CarouselCollection
     */
    public ClearCarouselItems(): void {
        this.CarouselCollection.clear();
    }
}

export class CarouselItemModel {

    constructor(
        src: string,
        alt: string,
    ) {
        this.Src = src;
        this.Alt = alt;
    }

    /**
     * Source image path.
     */
    public Src: string;

    /**
     * Alternative image text description.
     */
    public Alt: string;
}