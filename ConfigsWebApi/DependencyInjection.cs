using System.Reflection;
using ConfigsInfraestructure.Extensions;
using ConfigsWebApi.Middlewares;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

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
        services.AddSwaggerGen(
                c =>
                {
                    ConfigureSwaggerDoc(c);
                });

        services.AddTransient<GlobalExceptionHandlingMiddleware>();

        return services;
    }

    /// <summary>
    /// Configures the web application with the necessary middleware and endpoints.
    /// </summary>
    /// <param name="app">The web application to configure.</param>
    /// <returns>The configured web application.</returns>
    public static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
            app.ApplyMigration();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
        app.MapControllers();

        return app;
    }

    /// <summary>
    /// Configures the Swagger documentation for the API.
    /// </summary>
    /// <param name="options">The <see cref="SwaggerGenOptions"/> used to configure Swagger.</param>
    private static void ConfigureSwaggerDoc(SwaggerGenOptions options)
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "IRI Configurations Web Api",
            Version = "v1",
            Description = "An ASP.NET Core Web API for managing the configurations for all clients to serve.",
            Contact = new OpenApiContact
            {
                Name = "Mario David Riguera Castillo",
                Url = new Uri("https://www.linkedin.com/in/mario-david-riguera-castillo/"),
            },
        });

        // Using System.Reflection;
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }
}