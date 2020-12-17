namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using NUnit.Framework;

    public class TestDockingInitializer
    {
        private const string DayPath = @"../../../../AdventOfCode/Day14/";
        private const string FilePathInputData = DayPath + "InputData.txt";
        private const string FilePathTestData = DayPath + "TestData.txt";
        private string[] testData;
        private string[] inputData;

        [SetUp]
        public void Setup()
        {
            this.testData = DockingInitializer.ReadFileAsArray(FilePathTestData);
            this.inputData = DockingInitializer.ReadFileAsArray(FilePathInputData);
        }

        [Test]
        public void TestGetInputData()
        {
            var localTestData = this.testData;
            Assert.AreEqual(4, localTestData.GetLength(0));
        }

        [Test]
        public void TestInitialize()
        {
            var initial = new int[2 ^ 35];
            var expected = new int[2 ^ 35];
            expected[7] = 101;
            expected[8] = 64;
            var updated = DockingInitializer.Initialize(initial, this.testData);

            Assert.AreEqual(expected, updated);
        }

        [Test]
        public void TestParseInstruction()
        {
        }


        [Test]
        public void FindAnswerDayThirteenPuzzleOne()
        {
            var localTestData = this.inputData;
            int startTimestamp = int.Parse(localTestData[0]);
            var busList = ShuttleSearcher.GetBusList(localTestData);
            (int departure, int waitTime, int busId) = ShuttleSearcher.EarliestDeparture(startTimestamp, busList);
            Assert.AreEqual(296, waitTime * busId);
            Assert.AreEqual(8, waitTime);
            Assert.AreEqual(1000517, departure);
            Assert.AreEqual(37, busId);
        }

        [Test]
        public void FindAnswerDayThirteenPuzzleTwo()
        {
            Assert.Warn("Not solved");
        }
    }
}