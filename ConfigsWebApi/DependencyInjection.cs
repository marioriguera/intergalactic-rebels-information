namespace ConfigsWebApi;

/// <summary>
/// Provides extension methods for adding presentation layer dependencies.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds presentation layer services to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the services will be added.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // Add services to the container.
        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}