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
            long answer = HomeworkSolver.Solve(problem);
            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestCase("(1+2)*(2+1)", 3)]
        [TestCase("((1+2)+(2+1))", 6)]
        public void TestGetArgument(string problem, int expectedArgument)
        {
            long argument = HomeworkSolver.GetArgument(ref problem);
            Assert.AreEqual(expectedArgument, argument);
        }

        [TestCase("(1+2)*(2+1)", 4)]
        [TestCase("((1+2)+(2+1))", 12)]
        public void TestFindEndParenthesis(string problem, int expectedIndex)
        {
            int index = HomeworkSolver.FindEndParenthesis(problem);
            Assert.AreEqual(expectedIndex, index);
        }

        [TestCase(0, 26)]
        [TestCase(1, 437)]
        [TestCase(2, 12240)]
        [TestCase(3, 13632)]
        public void TestSolve(int iProblem, int expectedAnswer)
        {
            long answer = HomeworkSolver.Solve(this.testData[iProblem]);
            Assert.AreEqual(expectedAnswer, answer);
        }

        [Test]
        public void TestSolveAll()
        {
            int expectedAnswer = 26 + 437 + 12240 + 13632;
            long answer = HomeworkSolver.SolveAll(this.testData);
            Assert.AreEqual(expectedAnswer, answer);
        }

        [Test]
        public void FindAnserDayEighteenPuzzleOne()
        {
            long answer = HomeworkSolver.SolveAll(this.inputData);
            Assert.AreEqual(11004703763391, answer);
        }

        [Test]
        public void FindAnserDaySixteenPuzzleTwo()
        {

            Assert.Warn("Not solved");
        }
    }
}