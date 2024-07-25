using ConfigsDomain.Entities;

namespace ConfigsDomain.Repositories;

/// <summary>
/// Interface for the repository to access home view data.
/// </summary>
public interface IHomeViewRepository
{
    /// <summary>
    /// Gets all configurations for home view sliders.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A read-only list of <see cref="HomeViewSlider"/> configurations.</returns>
    IReadOnlyList<HomeViewSlider> GetAllHomeViewSlidersConfigurations(CancellationToken cancellationToken = default);
}