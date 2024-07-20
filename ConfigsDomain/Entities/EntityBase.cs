namespace ConfigsDomain.Entities;

/// <summary>
/// Represents the base class for entities with a unique identifier, supporting generic type constraints.
/// </summary>
/// <typeparam name="T">The type of the entity that inherits from this base class.</typeparam>
public abstract class EntityBase<T> : IEquatable<T>
    where T : EntityBase<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityBase{T}"/> class with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier for the entity.</param>
    public EntityBase(Guid id)
    {
        Id = id;
    }

    /// <summary>
    /// Gets or sets the unique identifier for the entity base.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Determines whether the specified <see cref="EntityBase{T}"/> instances are considered equal.
    /// </summary>
    /// <param name="left">The first <see cref="EntityBase{T}"/> to compare.</param>
    /// <param name="right">The second <see cref="EntityBase{T}"/> to compare.</param>
    /// <returns><c>true</c> if the specified <see cref="EntityBase{T}"/> instances are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(EntityBase<T>? left, EntityBase<T>? right)
    {
        if (left is null)
            return right is null;

        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether the specified <see cref="EntityBase{T}"/> instances are not considered equal.
    /// </summary>
    /// <param name="left">The first <see cref="EntityBase{T}"/> to compare.</param>
    /// <param name="right">The second <see cref="EntityBase{T}"/> to compare.</param>
    /// <returns><c>true</c> if the specified <see cref="EntityBase{T}"/> instances are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(EntityBase<T>? left, EntityBase<T>? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Determines whether the specified <typeparamref name="T"/> is equal to the current <typeparamref name="T"/>.
    /// </summary>
    /// <param name="other">The <typeparamref name="T"/> to compare with the current <typeparamref name="T"/>.</param>
    /// <returns><c>true</c> if the specified <typeparamref name="T"/> is equal to the current <typeparamref name="T"/>; otherwise, <c>false</c>.</returns>
    public bool Equals(T? other) => other?.Id.Equals(Id) ?? false;

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj) => obj is EntityBase<T> && Equals(obj as EntityBase<T>);

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}