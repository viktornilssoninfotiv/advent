using NUnit.Framework;
using System.Collections.Generic;

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
            int x, y, sum;
            var numbers = new List<int>() { 1, 2, 3, 4 };

            sum = 3;
            (x, y) = report.FindSum(numbers, sum);
            Assert.AreEqual(x + y, sum);
        }
    }
}