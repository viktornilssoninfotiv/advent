using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
            (x, y) = ExpepenseReport.FindSum(numbers, sum);
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
            (x, y) = ExpepenseReport.FindSum(numbers, sum);
            Assert.AreNotEqual(x + y, sum);
        }

        [Test]
        public void TestFindSumAnswer()
        {
            int num1, num2;
            int desiredSum = 2020;
            // Find the answer to day 1 challange 1
            ExpepenseReport report = new ExpepenseReport();
            var input = report.GetInputData();
            (num1, num2) = ExpepenseReport.FindSum(input, desiredSum);
            Assert.AreEqual(num1 + num2, desiredSum);
            int answer = num1 * num2;
            Console.Write(answer);
        }

        [Test]
        public void TestFindTrippleSumAnwser()
        {
            int desiredSum = 2020;
            var numbers = new List<int>();

            // Find the answer to day 1 challange 2
            ExpepenseReport report = new ExpepenseReport();
            var input = report.GetInputData();
            numbers = report.FindTrippleSum(input, desiredSum);
            Assert.AreEqual(numbers.Sum(), desiredSum);
            int answer = numbers.Aggregate((x, y) => x * y);
            Console.Write(answer);
        }
    }
}