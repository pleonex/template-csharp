namespace MyLibrary;

using System.Reflection;

/// <summary>
/// Version of the library.
/// </summary>
public static class LibVersion
{
    /// <summary>
    /// Gets the version of the library.
    /// </summary>
    /// <returns>The version of the library.</returns>
    public static string GetVersion()
    {
        Assembly library = typeof(LibVersion).Assembly;
        return library.GetName()?.Version?.ToString() ?? "0.0.1";
    }
}
