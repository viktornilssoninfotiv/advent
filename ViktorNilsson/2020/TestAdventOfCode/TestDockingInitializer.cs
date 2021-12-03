namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            var initial = new Dictionary<long, long>();
            var expected = new Dictionary<long, long>();
            expected[7] = 101;
            expected[8] = 64;
            var updated = DockingInitializer.Initialize(initial, this.testData);

            Assert.AreEqual(expected, updated);
        }

        [Test]
        public void TestSum()
        {
            var initial = new Dictionary<long, long>();
            var updated = DockingInitializer.Initialize(initial, this.testData);
            long sum = DockingInitializer.Sum(updated);

            Assert.AreEqual(165, sum);
        }

        [Test]
        public void FindAnswerDayThirteenPuzzleOne()
        {
            var initial = new Dictionary<long, long>();
            var updated = DockingInitializer.Initialize(initial, this.inputData);
            long sum = DockingInitializer.Sum(updated);

            Assert.AreEqual(1, sum);
        }

        [Test]
        public void FindAnswerDayThirteenPuzzleTwo()
        {
            Assert.Warn("Not solved");
        }
    }
}