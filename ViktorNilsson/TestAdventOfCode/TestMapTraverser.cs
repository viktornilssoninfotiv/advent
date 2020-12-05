using NUnit.Framework;
using System;

namespace TestAdventOfCode
{
    public class TestMapTraverser
    {
        private const string PuzzleFilePath = "../../../../AdventOfCode/DayThreeInput.txt";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetInputDataSize()
        {
            MapTraverser traverser = new MapTraverser();
            char[,] map = traverser.GetInputData(PuzzleFilePath);
            Assert.AreEqual(323, map.GetLength(0));
            Assert.AreEqual(31, map.GetLength(1));
            Assert.AreEqual('.', map[0, 0]);
        }

        [Test]
        public void TestTreeCounter()
        {
            MapTraverser traverser = new MapTraverser();
            int down = 1;
            int right = 3;
            char[,] map = traverser.GetInputData("../../../DayThreeTestData.txt");
            int noOfTrees = traverser.TreeCounter(map, down, right);
            Assert.AreEqual(7, noOfTrees);
        }

        [Test]
        public void SolveDayThreePuzzelOne()
        {
            MapTraverser traverser = new MapTraverser();
            int down = 1;
            int right = 3;
            char[,] map = traverser.GetInputData(PuzzleFilePath);
            int noOfTrees = traverser.TreeCounter(map, down, right);
            Console.WriteLine(noOfTrees);
            Assert.AreEqual(558, noOfTrees);
        }
    }
}