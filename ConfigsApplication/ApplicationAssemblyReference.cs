using System.Reflection;

namespace ConfigsApplication;

/// <summary>
/// Provides a reference to the application assembly.
/// </summary>
public class ApplicationAssemblyReference
{
    /// <summary>
    /// Gets the current application assembly.
    /// </summary>
    public static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
}