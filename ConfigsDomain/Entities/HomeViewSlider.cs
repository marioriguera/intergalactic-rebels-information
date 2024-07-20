namespace ConfigsDomain.Entities;

/// <summary>
/// Represents a home view slider.
/// </summary>
public class HomeViewSlider : EntityBase<HomeViewSlider>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HomeViewSlider"/> class with default values.
    /// </summary>
    public HomeViewSlider()
        : this(Guid.Empty, string.Empty, string.Empty)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HomeViewSlider"/> class with specified values.
    /// </summary>
    /// <param name="id">The unique identifier for the slider.</param>
    /// <param name="src">The source URL of the slider image.</param>
    /// <param name="alt">The alt text for the slider image.</param>
    public HomeViewSlider(Guid id, string src, string alt)
        : base(id)
    {
        Id = id;
        Src = src;
        Alt = alt;
    }

    /// <summary>
    /// Gets or sets the source URL of the slider image.
    /// </summary>
    public string Src { get; set; }

    /// <summary>
    /// Gets or sets the alt text for the slider image.
    /// </summary>
    public string Alt { get; set; }
}