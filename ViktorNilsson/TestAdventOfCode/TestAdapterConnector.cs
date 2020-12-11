using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestAdventOfCode
{
    public class TestAdapterConnector
    {
        private const string Day = "Ten";
        private const string FilePathInputData = "../../../../AdventOfCode/InputData/Day" + Day + "Input.txt";
        private const string FilePathInputData2 = "../../../../AdventOfCode/InputData/Day" + Day + "Input2.txt";
        private const string FilePathTestData = "../../../TestData/Day" + Day + "TestData.txt";
        private List<int> testData;
        private List<int> inputData;

        [SetUp]
        public void Setup()
        {
            this.testData = AdapterConnector.GetInputData(FilePathTestData);
            this.inputData = AdapterConnector.GetInputData(FilePathInputData);
        }

        [Test]
        public void TestGetInputData()
        {
            var localTestData = this.testData;
            Assert.AreEqual(11, localTestData.Count);
            Assert.AreEqual(1, localTestData[0]);
        }

        [Test]
        public void TestConnect()
        {
            var localTestData = this.testData;
            var joltDiff = AdapterConnector.Connect(localTestData);
            Assert.AreEqual(5, joltDiff.three);
            Assert.AreEqual(7, joltDiff.one);
        }

        [Test]
        public void FindAnswerDayTenPuzzleOne()
        {
            var joltDiff = AdapterConnector.Connect(this.inputData);
            Assert.AreEqual(24, joltDiff.three);
            Assert.AreEqual(69, joltDiff.one);
            Assert.AreEqual(1656, joltDiff.three * joltDiff.one);
        }

        [Test]
        public void FindAnswerDayNinePuzzleTwo()
        {



        }
    }
}