using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ConfigsInfraestructure.Persistence;

/// <summary>
/// Factory for creating instances of <see cref="ApplicationDbContext"/> at design time.
/// </summary>
internal sealed class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    /// <summary>
    /// Creates a new instance of <see cref="ApplicationDbContext"/> with the specified arguments.
    /// </summary>
    /// <param name="args">Arguments passed by the design-time context creation process.</param>
    /// <returns>A new instance of <see cref="ApplicationDbContext"/>.</returns>
    /// <inheritdoc/>
    ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
    {
        var apiProjectPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\ConfigsWebApi");
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(apiProjectPath)
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        string connectionString = configuration.GetConnectionString("SqlServer") ?? throw new InvalidOperationException($"Can't create db context because string connection is null.");
        if (connectionString.Equals(string.Empty)) throw new InvalidOperationException($"Can't create db context because string connection is empty.");
        optionsBuilder.ConfigureOptionsBuilderUsingSql(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}