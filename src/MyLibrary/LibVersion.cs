namespace MyLibrary
{
    using System.Reflection;

    public static class LibVersion
    {
        public static string GetVersion()
        {
            Assembly library = typeof(LibVersion).Assembly;
            return library.GetName().Version.ToString();
        }
    }
}
