using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ConfigsInfraestructure.Persistence;

internal sealed class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    /// <inheritdoc/>
    ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
    {
        var apiProjectPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\ConfigsWebApi");
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(apiProjectPath)
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        string connectionString = configuration.GetConnectionString("SqlServer") ?? throw new InvalidOperationException($"Can't create db context because string connection its null.");
        if (connectionString.Equals(string.Empty)) throw new InvalidOperationException($"Can't create db context because string connection its empty.");
        optionsBuilder.ConfigureOptionsBuilderUsingSql(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
