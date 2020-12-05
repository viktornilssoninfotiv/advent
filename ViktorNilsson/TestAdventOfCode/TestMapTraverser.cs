using NUnit.Framework;
using System;

namespace TestAdventOfCode
{
    public class TestMapTraverser
    {
        private const string PuzzleFilePath = "../../../../AdventOfCode/DayThreeInput.txt";
        private const string TestDataFilePath = "../../../DayThreeTestData.txt";
        private int[,] slopes = new int[,] { { 1, 1 }, { 3, 1 }, { 5, 1 }, { 7, 1 }, { 1, 2 } };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetInputData()
        {
            MapTraverser traverser = new MapTraverser();
            char[,] map = traverser.GetInputData(PuzzleFilePath);
            Assert.AreEqual(323, map.GetLength(0));
            Assert.AreEqual(31, map.GetLength(1));
            Assert.AreEqual('.', map[0, 0]);
        }

        [TestCase(1, 1, 2)]
        [TestCase(3, 1, 7)]
        [TestCase(5, 1, 3)]
        [TestCase(7, 1, 4)]
        [TestCase(1, 2, 2)]
        public void TestTreeCounter(int right, int down, int expectedTrees)
        {
            MapTraverser traverser = new MapTraverser();
            char[,] map = traverser.GetInputData(TestDataFilePath);
            int noOfTrees = traverser.TreeCounter(map, right, down);
            Assert.AreEqual(expectedTrees, noOfTrees);
        }

        [Test]
        public void SolveDayThreePuzzelOne()
        {
            MapTraverser traverser = new MapTraverser();
            int down = 1;
            int right = 3;
            char[,] map = traverser.GetInputData(PuzzleFilePath);
            int noOfTrees = traverser.TreeCounter(map, right, down);
            Console.WriteLine(noOfTrees);
            Assert.AreEqual(225, noOfTrees);
        }

        [Test]
        public void TestTreeCounterMultiSlope()
        {
            MapTraverser traverser = new MapTraverser();
            char[,] map = traverser.GetInputData(TestDataFilePath);
            int noOfTrees = traverser.TreeCounterMultiSlope(map, this.slopes);
            Assert.AreEqual(336, noOfTrees);
        }

        [Test]
        public void SolveDayThreePuzzelTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            MapTraverser traverser = new MapTraverser();
            char[,] map = traverser.GetInputData(PuzzleFilePath);
            int noOfTrees = traverser.TreeCounterMultiSlope(map, this.slopes);
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Assert.AreEqual(1115775000, noOfTrees);
        }
    }
}