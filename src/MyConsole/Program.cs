string consoleVersion = typeof(Program).Assembly.GetName()?.Version?.ToString() ?? "0.0.1";
Console.WriteLine($"Console version: {consoleVersion}");

string libVersion = MyLibrary.LibVersion.GetVersion();
Console.WriteLine($"Library version: {libVersion}");
