namespace MyTests;

using MyLibrary;
using NUnit.Framework;

[TestFixture]
public class VersionTests
{
    [Test]
    public void TestVersionNotNull()
    {
        Assert.That(LibVersion.GetVersion(), Is.Not.Null);
    }
}
