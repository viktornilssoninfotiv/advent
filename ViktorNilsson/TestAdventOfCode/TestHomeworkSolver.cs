namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    public class TestHomeworkSolver
    {
        private const string DayPath = @"../../../../AdventOfCode/Day18/";
        private const string FilePathInputData = DayPath + "InputData.txt";
        private const string FilePathTestData = DayPath + "TestData.txt";
        private string[] testData;
        private string[] inputData;

        [SetUp]
        public void Setup()
        {
            this.testData = HomeworkSolver.ReadFileAsArray(FilePathTestData);
            this.inputData = HomeworkSolver.ReadFileAsArray(FilePathInputData);
        }

        [Test]
        public void TestReadInputData()
        {
            Assert.AreEqual(4, this.testData.Length);
        }

        [TestCase("1+1", 2)]
        [TestCase("2*2", 4)]
        [TestCase("1+2*2", 6)]
        [TestCase("1+1+2*2", 8)]
        [TestCase("1+2*(2+1)", 9)]
        [TestCase("(1+2)*(2+1)", 9)]
        public void TestSolveSimple(string problem, int expectedAnswer)
        {
            int answer = HomeworkSolver.Solve(problem);
            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestCase(0, 26)]
        [TestCase(1, 437)]
        [TestCase(2, 12240)]
        [TestCase(3, 13622)]
        public void TestSolve(int iProblem, int expectedAnswer)
        {
            int answer = HomeworkSolver.Solve(this.testData[iProblem]);
            Assert.AreEqual(expectedAnswer, answer);
        }

        [Test]
        public void FindAnserDaySixteenPuzzleOne()
        {
            Assert.Warn("Not solved");
        }

        [Test]
        public void FindAnserDaySixteenPuzzleTwo()
        {

            Assert.Warn("Not solved");
        }
    }
}