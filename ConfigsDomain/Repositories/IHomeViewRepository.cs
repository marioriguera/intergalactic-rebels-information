using ConfigsDomain.Entities;

namespace ConfigsDomain.Repositories;

public interface IHomeViewRepository
{
    Task<IReadOnlyList<HomeViewSlider>> GetAllHomeViewSlidersConfigurationsAsync(CancellationToken cancellationToken = default);
}
