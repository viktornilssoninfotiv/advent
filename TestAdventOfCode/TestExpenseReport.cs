using NUnit.Framework;

namespace TestAdventOfCode
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFindSum()
        {
            ExpepenseReport report = new ExpepenseReport();
            report.FindSum();
            Assert.Pass();
        }
    }
}