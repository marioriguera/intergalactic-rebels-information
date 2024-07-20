using System.Reflection;

namespace ConfigsInfraestructure;

/// <summary>
/// Provides a reference to the infrastructure assembly.
/// </summary>
public static class InfraestructureAssemblyReference
{
    /// <summary>
    /// Gets the current infrastructure assembly.
    /// </summary>
    public static readonly Assembly Assembly = typeof(InfraestructureAssemblyReference).Assembly;
}