namespace MyTests
{
    using NUnit.Framework;
    using MyLibrary;

    public class Tests
    {
        [Test]
        public void TestVersionNotNull()
        {
            Assert.That(LibVersion.GetVersion(), Is.Not.Null);
        }
    }
}
