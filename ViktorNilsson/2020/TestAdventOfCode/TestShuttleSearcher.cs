namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using NUnit.Framework;

    public class TestShuttleSearcher
    {
        private const string DayPath = @"../../../../AdventOfCode/Day13/";
        private const string FilePathInputData = DayPath + "InputData.txt";
        private const string FilePathTestData = DayPath + "TestData.txt";
        private string[] testData;
        private string[] inputData;

        [SetUp]
        public void Setup()
        {
            this.testData = ShuttleSearcher.ReadFileAsArray(FilePathTestData);
            this.inputData = ShuttleSearcher.ReadFileAsArray(FilePathInputData);
        }

        [Test]
        public void TestGetInputData()
        {
            var localTestData = this.testData;
            Assert.AreEqual(2, localTestData.GetLength(0));
        }

        [TestCase(0, 7, 7)]
        [TestCase(939, 59, 944)]
        public void TestNextDeparture(int startTimestamp, int busId, int expectedDeparture)
        {
            int departure = ShuttleSearcher.NextDeparture(startTimestamp, busId);
            Assert.AreEqual(expectedDeparture, departure);
        }

        [Test]
        public void TestGetBusIds()
        {
            var expectedBusList = new List<int> { 7, 13, 19, 31, 59 };
            List<int> busList = ShuttleSearcher.GetBusList(this.testData);
            Assert.AreEqual(5, busList.Count);
            Assert.AreEqual(expectedBusList, busList);
        }

        [Test]
        public void TestGetBusIdsSorted()
        {
            List<int> busList = ShuttleSearcher.GetBusList(this.testData);
            List<int> expectedList = busList;
            expectedList.Sort();
            Assert.AreEqual(expectedList, busList);
        }

        [Test]
        public void TestEarliestDeparture()
        {
            var localTestData = this.testData;
            int startTimestamp = int.Parse(localTestData[0]);
            var busList = ShuttleSearcher.GetBusList(localTestData);
            (int departure, int waitTime, int busId) = ShuttleSearcher.EarliestDeparture(startTimestamp, busList);
            Assert.AreEqual(5, waitTime);
            Assert.AreEqual(944, departure);
            Assert.AreEqual(59, busId);
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