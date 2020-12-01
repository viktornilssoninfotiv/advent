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
        public void TestGetInputData()
        {
            var numbers = new List<int>();
            numbers = new ExpepenseReport().GetInputData();
            Assert.IsNotNull(numbers);
            Assert.Contains(1918, numbers);
        }

        [Test]
        public void TestFindSum()
        {
            int x, y, sum;
            var numbers = new List<int>() { 1, 2, 3, 4 };

            sum = 5;
            (x, y) = new ExpepenseReport().FindSum(numbers, sum);
            Assert.AreEqual(x + y, sum);
            Assert.Contains(x, numbers);
            Assert.Contains(y, numbers);
        }

        [Test]
        public void TestFindSumNotInSum()
        {
            int x, y, sum;
            var numbers = new List<int>() { 1, 2, 3, 4 };

            sum = 20;
            (x, y) = new ExpepenseReport().FindSum(numbers, sum);
            Assert.AreNotEqual(x + y, sum);
        }

    }
}