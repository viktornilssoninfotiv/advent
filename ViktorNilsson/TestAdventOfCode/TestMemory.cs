namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using NUnit.Framework;

    public class TestMemory
    {
        private const string DayPath = @"../../../../AdventOfCode/Day15/";
        private const string FilePathInputData = DayPath + "InputData.txt";
        private const string FilePathTestData = DayPath + "TestData.txt";
        private List<int> testData;
        private List<int> inputData;

        [SetUp]
        public void Setup()
        {
            this.testData = new List<int>() { 0, 3, 6 };
            this.inputData = new List<int>() { 16, 11, 15, 0, 1, 7 };
        }

        [TestCase(1, 0)]
        [TestCase(2, 3)]
        [TestCase(3, 6)]
        [TestCase(4, 0)]
        [TestCase(5, 3)]
        [TestCase(6, 3)]
        [TestCase(7, 1)]
        public void TestRound(int i, int expected)
        {
            var num = Memory.Round(i, this.testData);

            Assert.AreEqual(expected, num);
        }


        [Test]
        public void FindAnswerDayFifteenPuzzleOne()
        {
            var num = Memory.Round(2020, this.inputData);

            Assert.AreEqual(662, num);
        }

        [Test]
        public void FindAnswerDayFifteenPuzzleTwo()
        {
            var num = Memory.Round(30000000, this.inputData);

            Assert.AreEqual(662, num);
        }
    }
}