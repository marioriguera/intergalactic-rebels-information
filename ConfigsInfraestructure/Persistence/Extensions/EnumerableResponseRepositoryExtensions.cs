using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ConfigsInfraestructure.Persistence.Extensions;

/// <summary>
/// Extension methods for managing entities in Redis cache and database.
/// </summary>
internal static class EnumerableResponseRepositoryExtensions
{
    /// <summary>
    /// Checks if entities are present in the Redis cache. If not, attempts to retrieve them from the cache.
    /// </summary>
    /// <typeparam name="T">The type of entities.</typeparam>
    /// <param name="entities">The list of entities to check and populate.</param>
    /// <param name="cache">The Redis distributed cache instance.</param>
    /// <param name="cacheKey">The cache key identifier for the entities.</param>
    /// <returns>The list of entities, populated from the cache if available.</returns>
    public static List<T> CheckInRedisCache<T>(
                            this List<T> entities,
                            IDistributedCache cache,
                            string cacheKey)
    {
        if (entities.Any()) return entities;

        var cachedData = cache.GetStringAsync(cacheKey)
                              .GetAwaiter()
                              .GetResult();

        if (!string.IsNullOrEmpty(cachedData))
        {
            var deserialized = JsonConvert.DeserializeObject<List<T>>(cachedData)
                               ?? Enumerable.Empty<T>()
                                            .ToList();

            entities.AddRange(deserialized);
        }

        return entities;
    }

    /// <summary>
    /// Checks if entities are present in the database if not found in the provided list.
    /// </summary>
    /// <typeparam name="T">The type of entities.</typeparam>
    /// <param name="entities">The list of entities to check and populate.</param>
    /// <param name="context">The <see cref="DbContext"/> instance for database access.</param>
    /// <param name="filter">Optional filter expression to apply when querying the database.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>The list of entities, populated from the database if available.</returns>
    public static List<T> CheckInDatabase<T>(
                            this List<T> entities,
                            DbContext context,
                            Expression<Func<T, bool>>? filter = null,
                            CancellationToken cancellationToken = default)
        where T : class
    {
        if (entities.Any()) return entities;

        var result = context.Set<T>()
                            .AsQueryable()
                            .Where(filter ?? (_ => true))
                            .ToListAsync(cancellationToken)
                            .GetAwaiter()
                            .GetResult();

        entities.AddRange(result);

        return entities;
    }

    /// <summary>
    /// Sets entities in the Redis cache with a specified expiration time.
    /// </summary>
    /// <typeparam name="T">The type of entities.</typeparam>
    /// <param name="entities">The list of entities to be cached.</param>
    /// <param name="cache">The Redis distributed cache instance.</param>
    /// <param name="cacheKey">The cache key identifier for the entities.</param>
    /// <param name="cacheExpiration">The time span for which the cache entry should be kept.</param>
    /// <returns>The list of entities.</returns>
    public static List<T> SetInRedisCache<T>(
                            this List<T> entities,
                            IDistributedCache cache,
                            string cacheKey,
                            TimeSpan cacheExpiration)
    {
        var data = cache.GetAsync(cacheKey)
                        .GetAwaiter()
                        .GetResult();

        if (data == null)
        {
            var serializedData = JsonConvert.SerializeObject(entities);
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = cacheExpiration,
            };

            cache.SetStringAsync(cacheKey, serializedData, options)
                 .GetAwaiter();
        }

        return entities;
    }
}