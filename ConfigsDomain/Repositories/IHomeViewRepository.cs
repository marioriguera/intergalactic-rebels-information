using ConfigsDomain.Entities;

namespace ConfigsDomain.Repositories;

/// <summary>
/// Interface for the repository to access home view data.
/// </summary>
public interface IHomeViewRepository
{
    /// <summary>
    /// Retrieves all configurations for home view sliders.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>
    /// The task result contains a read-only list of <see cref="HomeViewSlider"/>.
    /// </returns>
    IReadOnlyList<HomeViewSlider> GetAllHomeViewSlidersConfigurations(CancellationToken cancellationToken = default);
}