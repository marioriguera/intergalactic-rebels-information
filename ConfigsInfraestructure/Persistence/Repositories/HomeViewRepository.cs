using ConfigsDomain.Entities;
using ConfigsDomain.Repositories;
using ConfigsInfraestructure.Persistence.Constants;
using ConfigsInfraestructure.Persistence.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace ConfigsInfraestructure.Persistence.Repositories;

/// <summary>
/// Repository for accessing home view data from the database and caching it in Redis.
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
    /// <param name="cache">The Redis distributed cache instance.</param>
    public HomeViewRepository(ApplicationDbContext context, IDistributedCache cache)
    {
        _context = context;
        _cache = cache;
    }

    /// <inheritdoc/>
    public IReadOnlyList<HomeViewSlider> GetAllHomeViewSlidersConfigurations(CancellationToken cancellationToken = default)
    {
        List<HomeViewSlider> homeViewSliders = [];

        homeViewSliders.CheckInRedisCache(_cache, CacheRedisIdentifiers.HomeViewSlidersId)
                       .CheckInDatabase(_context, cancellationToken: cancellationToken)
                       .SetInRedisCache(_cache, CacheRedisIdentifiers.HomeViewSlidersId, _cacheExpiration);

        return homeViewSliders;
    }
}