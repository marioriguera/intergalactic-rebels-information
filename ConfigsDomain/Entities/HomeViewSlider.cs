namespace ConfigsDomain.Entities;

/// <summary>
/// Represents a home view slider.
/// </summary>
public class HomeViewSlider : IEquatable<HomeViewSlider>
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
    {
        Id = id;
        Src = src;
        Alt = alt;
    }

    /// <summary>
    /// Gets or sets the unique identifier for the slider.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the source URL of the slider image.
    /// </summary>
    public string Src { get; set; }

    /// <summary>
    /// Gets or sets the alt text for the slider image.
    /// </summary>
    public string Alt { get; set; }

    /// <summary>
    /// Determines whether the specified <see cref="HomeViewSlider"/> is equal to the current <see cref="HomeViewSlider"/>.
    /// </summary>
    /// <param name="other">The <see cref="HomeViewSlider"/> to compare with the current <see cref="HomeViewSlider"/>.</param>
    /// <returns><c>true</c> if the specified <see cref="HomeViewSlider"/> is equal to the current <see cref="HomeViewSlider"/>; otherwise, <c>false</c>.</returns>
    public bool Equals(HomeViewSlider? other) => other?.Id.Equals(Id) ?? false;

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object? obj) => obj is HomeViewSlider && base.Equals(obj);

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        int hash = 17;
        hash = (hash * 23) + Id.GetHashCode();
        hash = (hash * 23) + (Src?.GetHashCode() ?? 0);
        hash = (hash * 23) + (Alt?.GetHashCode() ?? 0);
        return hash;
    }
}