using ConfigsDomain.Repositories;

namespace ConfigsInfraestructure.Persistence;

/// <summary>
/// Implements the unit of work pattern, managing database transactions and saving changes.
/// </summary>
internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="dbContext">The <see cref="ApplicationDbContext"/> to use for database operations.</param>
    public UnitOfWork(ApplicationDbContext dbContext) => _dbContext = dbContext;

    /// <summary>
    /// Asynchronously saves changes made in the unit of work to the database.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the save operation.</param>
    /// <returns>A task that represents the asynchronous save operation.</returns>
    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _dbContext.SaveChangesAsync(cancellationToken);
}