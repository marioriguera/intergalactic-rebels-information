using ConfigsDomain.Entities;
using ConfigsDomain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ConfigsInfraestructure.Persistence.Repositories;

internal sealed class HomeViewRepository : IHomeViewRepository
{
    private readonly ApplicationDbContext _context;

    public HomeViewRepository(ApplicationDbContext context) => _context = context;

    public async Task<IReadOnlyList<HomeViewSlider>> GetAllHomeViewSlidersConfigurationsAsync(CancellationToken cancellationToken = default)
        => await _context.HomeViewSlidersConfigs.AsQueryable().ToListAsync(cancellationToken: cancellationToken);
}
