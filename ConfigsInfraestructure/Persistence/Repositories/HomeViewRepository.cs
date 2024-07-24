using ConfigsDomain.Entities;
using ConfigsDomain.Repositories;
using ConfigsInfraestructure.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

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
    /// A task that represents the asynchronous operation.
    /// The task result contains a read-only list of <see cref="HomeViewSlider"/>.
    /// </returns>
    public async Task<IReadOnlyList<HomeViewSlider>> GetAllHomeViewSlidersConfigurationsAsync(CancellationToken cancellationToken = default)
    {
        List<HomeViewSlider> homeViewSliders = new();

        // I am wondering if each of the extension functions are executed outside the main thread. <= ToDo: Prueba esto.
        await homeViewSliders.CheckConfigsInRedisCache(_cache).Result
                             .CheckConfigsInDatabase(_context, cancellationToken).Result
                             .SetConfigsInRedisCache(_cache, _cacheExpiration);

        return homeViewSliders;
    }
}

// ToDo: Hacer de la siguiente clase algo más generico para que funcione con cualquier contacto con base de datos.

/// <summary>
/// Extension methods for managing home view sliders in the Redis cache and database.
/// </summary>
internal static class HomeViewRepositoryExtensions
{
    /// <summary>
    /// Checks if home view sliders are present in the Redis cache. If not, attempts to retrieve them from the cache.
    /// </summary>
    /// <param name="homeViewSliders">The list of home view sliders to check and populate.</param>
    /// <param name="cache">The Redis distributed cache instance.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of home view sliders.</returns>
    internal static async Task<List<HomeViewSlider>> CheckConfigsInRedisCache(this List<HomeViewSlider> homeViewSliders, IDistributedCache cache)
    {
        var cachedData = await cache.GetStringAsync(CacheRedisIdentifiers.HomeViewSlidersId);

        if (!string.IsNullOrEmpty(cachedData))
        {
            var deserialized = JsonConvert.DeserializeObject<List<HomeViewSlider>>(cachedData) ?? Enumerable.Empty<HomeViewSlider>().ToList();
            homeViewSliders.AddRange(deserialized);
            return homeViewSliders;
        }

        return homeViewSliders;
    }

    /// <summary>
    /// Checks if home view sliders are present in the database if not found in the provided list.
    /// </summary>
    /// <param name="homeViewSliders">The list of home view sliders to check and populate.</param>
    /// <param name="context">The <see cref="ApplicationDbContext"/> instance for database access.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of home view sliders from the database.</returns>
    internal static async Task<List<HomeViewSlider>> CheckConfigsInDatabase(this List<HomeViewSlider> homeViewSliders, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        if (homeViewSliders.Any()) return homeViewSliders;
        homeViewSliders.AddRange(await context.HomeViewSlidersConfigs.AsQueryable().ToListAsync(cancellationToken: cancellationToken));
        return homeViewSliders;
    }

    /// <summary>
    /// Sets home view sliders in the Redis cache with a specified expiration time.
    /// </summary>
    /// <param name="homeViewSliders">The list of home view sliders to be cached.</param>
    /// <param name="cache">The Redis distributed cache instance.</param>
    /// <param name="cacheExpiration">The time span for which the cache entry should be kept.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    internal static async Task SetConfigsInRedisCache(this List<HomeViewSlider> homeViewSliders, IDistributedCache cache, TimeSpan cacheExpiration)
    {
        var data = await cache.GetAsync(CacheRedisIdentifiers.HomeViewSlidersId);

        if (data != null) return;

        var serializedData = JsonConvert.SerializeObject(homeViewSliders);
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = cacheExpiration,
        };
        await cache.SetStringAsync(CacheRedisIdentifiers.HomeViewSlidersId, serializedData, options);
    }
}