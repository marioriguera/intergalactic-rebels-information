using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigsInfraestructure.Persistence.Extensions;

/// <summary>
/// Provides extension methods for applying database migrations.
/// </summary>
public static class MigrationExtension
{
    /// <summary>
    /// Applies any pending migrations for the database context to the database.
    /// Creates a scope, retrieves the <see cref="ApplicationDbContext"/> from the service provider,
    /// and applies migrations if there are any pending.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance to use for applying migrations.</param>
    /// <exception cref="InvalidOperationException">Thrown when <see cref="ApplicationDbContext"/> cannot be retrieved from the service provider.</exception>
    public static void ApplyMigration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        System.Console.WriteLine("Traying to apply migrations.");
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>()
                        ?? throw new InvalidOperationException($"Can't get {nameof(ApplicationDbContext)} from services.");

        if (!dbContext.Database.CanConnect())
        {
            System.Console.WriteLine($"Can't connect with database in: {dbContext.Database.GetConnectionString()} .");
            System.Console.WriteLine($"Maybe the database not exist.");
        }

        try
        {
            if (!dbContext.Database.GetPendingMigrations().Any())
            {
                System.Console.WriteLine("Database dont have pending migrations.");
                return;
            }

            dbContext.Database.Migrate();
            System.Console.WriteLine("Migrations apply.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An unhandled exception has occurred trying to perform pending migrations. Message: {ex.Message}");
        }
    }
}