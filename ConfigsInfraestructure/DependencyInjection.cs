using ConfigsInfraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigsInfraestructure;

/// <summary>
/// Provides extension methods for adding infrastructure services to the service collection.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds infrastructure services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to which the services are added.</param>
    /// <param name="configuration">The configuration used to configure the services.</param>
    /// <returns>The service collection with the added services.</returns>
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connection = configuration.GetConnectionString("SqlServer")
            ?? throw new ArgumentNullException($"Connection string its null.");

        services.Scan(
                selector => selector
                .FromAssemblies(InfraestructureAssemblyReference.Assembly)
                .AddClasses(false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        services.AddDbContext<ApplicationDbContext>(
            (sp, optionsBuilder) =>
            {
                optionsBuilder.ConfigureOptionsBuilderUsingSql(connection);
            });

        services.AddRedisCache(configuration);

        return services;
    }

    /// <summary>
    /// Configures the <see cref="DbContextOptionsBuilder"/> to use SQL Server with specified retry options.
    /// </summary>
    /// <param name="dbContextOptions">The <see cref="DbContextOptionsBuilder"/> to configure.</param>
    /// <param name="connectionString">The connection string for the SQL Server database.</param>
    /// <returns>The configured <see cref="DbContextOptionsBuilder"/>.</returns>
    public static DbContextOptionsBuilder ConfigureOptionsBuilderUsingSql(this DbContextOptionsBuilder dbContextOptions, string connectionString)
    {
        dbContextOptions.UseSqlServer(
            connectionString,
            sqlOptions => sqlOptions.EnableRetryOnFailure(
                                maxRetryCount: 5,
                                maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorNumbersToAdd: null))
                        .EnableDetailedErrors();
        return dbContextOptions;
    }

    /// <summary>
    /// Adds Redis cache services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> containing the Redis configuration.</param>
    /// <returns>The <see cref="IServiceCollection"/> with the Redis cache services added.</returns>
    private static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConnectionString = configuration["Redis:ConnectionString"];
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnectionString;
        });

        return services;
    }
}