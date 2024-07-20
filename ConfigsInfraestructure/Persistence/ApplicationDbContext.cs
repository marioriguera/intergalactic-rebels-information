using Microsoft.EntityFrameworkCore;

namespace ConfigsInfraestructure.Persistence;

/// <summary>
/// Represents the application database context for managing entities and database operations.
/// </summary>
internal class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The options to configure the database context.</param>
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    /// <summary>
    /// Configures the model creating process by applying entity configurations from the assembly.
    /// </summary>
    /// <param name="modelBuilder">The <see cref="ModelBuilder"/> used to build the model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(InfraestructureAssemblyReference.Assembly);
}