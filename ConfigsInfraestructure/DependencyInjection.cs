using ConfigsInfraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        return services;
    }

    public static DbContextOptionsBuilder ConfigureOptionsBuilderUsingSql(this DbContextOptionsBuilder dbContextOptions, string connectionString)
    {
        dbContextOptions.UseSqlServer(connectionString,
                            sqlOptions => sqlOptions.EnableRetryOnFailure(
                                maxRetryCount: 5,
                                maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorNumbersToAdd: null))
                        .EnableDetailedErrors();
        return dbContextOptions;
    }
}