using ConfigsDomain.Entities;
using ConfigsDomain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ConfigsInfraestructure.Persistence.Repositories;

/// <summary>
/// Repository for accessing home view data from the database.
/// </summary>
internal sealed class HomeViewRepository : IHomeViewRepository
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="HomeViewRepository"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    public HomeViewRepository(ApplicationDbContext context) => _context = context;

    /// <summary>
    /// Retrieves all configurations for home view sliders from the database.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a read-only list of <see cref="HomeViewSlider"/>.
    /// </returns>
    public async Task<IReadOnlyList<HomeViewSlider>> GetAllHomeViewSlidersConfigurationsAsync(CancellationToken cancellationToken = default)
        => await _context.HomeViewSlidersConfigs.AsQueryable().ToListAsync(cancellationToken: cancellationToken);
}