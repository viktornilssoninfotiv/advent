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
            AdventOfCode.ExpenseReport.FindSum();
            Assert.Pass();
        }
    }
}