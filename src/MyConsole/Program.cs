using System;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string consoleVersion = typeof(Program).Assembly.GetName().Version.ToString();
            Console.WriteLine($"Console version: {consoleVersion}");

            string libVersion = MyLibrary.LibVersion.GetVersion();
            Console.WriteLine($"Library version: {libVersion}");
        }
    }
}
