using ConfigsApplication.Commons;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigsApplication;

/// <summary>
/// Provides extension methods for adding application services to the service collection.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds application services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to which the services are added.</param>
    /// <returns>The service collection with the added services.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
        });

        services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();

        return services;
    }
}