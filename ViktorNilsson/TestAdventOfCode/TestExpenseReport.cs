using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestAdventOfCode
{
    public class TestExpenseReport
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestGetInputData()
        {
            List<int> numbers = ExpepenseReport.GetInputData();
            Assert.IsNotNull(numbers);
            Assert.Contains(1918, numbers);
        }

        [Test]
        public void TestFindSum()
        {
            int desiredSum = 5;
            var input = new List<int>() { 1, 2, 3, 4 };

            List<int> numbers = ExpepenseReport.FindSum(input, desiredSum);
            Assert.AreEqual(numbers.Count(), 2);
            Assert.AreEqual(numbers.Sum(), desiredSum);
            Assert.Contains(numbers[0], input);
            Assert.Contains(numbers[1], input);
        }

        [Test]
        public void TestFindSumNotInSum()
        {
            int desiredSum = 20;
            var input = new List<int>() { 1, 2, 3, 4 };

            List<int> numbers = ExpepenseReport.FindSum(input, desiredSum);
            Assert.AreEqual(numbers.Count(), 0);
        }

        [Test]
        public void TestFindSumAnswer()
        {
            int desiredSum = 2020;

            // Find the answer to day 1 challange 1
            var input = ExpepenseReport.GetInputData();
            List<int> numbers = ExpepenseReport.FindSum(input, desiredSum);
            Assert.AreEqual(numbers.Sum(), desiredSum);
            int answer = numbers.Aggregate((x, y) => x * y);
            Console.Write(answer);
        }

        [Test]
        public void TestFindTrippleSumAnwser()
        {
            int desiredSum = 2020;

            // Find the answer to day 1 challange 2
            var input = ExpepenseReport.GetInputData();
            List<int> numbers = ExpepenseReport.FindTrippleSum(input, desiredSum);
            Assert.AreEqual(numbers.Sum(), desiredSum);
            int answer = numbers.Aggregate((x, y) => x * y);
            Console.Write(answer);
        }
    }
}