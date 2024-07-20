using ConfigsDomain.Entities;

namespace ConfigsDomain.Repositories;

public interface IHomeViewRepository
{
    Task<IReadOnlyList<HomeViewSlider>> GetAllHomeViewSlidersConfigurations();
}
