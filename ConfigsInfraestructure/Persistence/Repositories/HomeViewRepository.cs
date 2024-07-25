using ConfigsDomain.Entities;
using ConfigsDomain.Repositories;
using ConfigsInfraestructure.Persistence.Constants;
using ConfigsInfraestructure.Persistence.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace ConfigsInfraestructure.Persistence.Repositories;

/// <summary>
/// Repository for accessing home view data from the database.
/// </summary>
internal sealed class HomeViewRepository : IHomeViewRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IDistributedCache _cache;
    private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(10);

    /// <summary>
    /// Initializes a new instance of the <see cref="HomeViewRepository"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    public HomeViewRepository(ApplicationDbContext context, IDistributedCache cache)
    {
        _context = context;
        _cache = cache;
    }

    /// <summary>
    /// Retrieves all configurations for home view sliders from the database.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>
    /// The task result contains a read-only list of <see cref="HomeViewSlider"/>.
    /// </returns>
    public IReadOnlyList<HomeViewSlider> GetAllHomeViewSlidersConfigurations(CancellationToken cancellationToken = default)
    {
        List<HomeViewSlider> homeViewSliders = [];

        homeViewSliders.CheckInRedisCache(_cache, CacheRedisIdentifiers.HomeViewSlidersId)
                       .CheckInDatabase(_context, cancellationToken: cancellationToken)
                       .SetInRedisCache(_cache, CacheRedisIdentifiers.HomeViewSlidersId, _cacheExpiration);

        return homeViewSliders;
    }
}