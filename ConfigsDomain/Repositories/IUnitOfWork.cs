namespace ConfigsDomain.Repositories;

/// <summary>
/// Defines the contract for a unit of work, which manages database transactions and ensures changes are saved.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Asynchronously saves changes made in the unit of work to the database.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the save operation.</param>
    /// <returns>A task that represents the asynchronous save operation.</returns>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}