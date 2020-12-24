namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    public class TestMessageValidator
    {
        private const string DayPath = @"../../../../AdventOfCode/Day19/";
        private const string FilePathInputData = DayPath + "InputData.txt";
        private const string FilePathTestData = DayPath + "TestData.txt";
        private string[] testData;
        private string[] inputData;

        [SetUp]
        public void Setup()
        {
            this.testData = MessageValidator.ReadFileAsArray(FilePathTestData);
            this.inputData = MessageValidator.ReadFileAsArray(FilePathInputData);
        }

        [Test]
        public void FindAnserDayNineteenPuzzleOne()
        {
            Assert.Warn("Not solved");
        }

        [Test]
        public void FindAnserDayNineteenPuzzleTwo()
        {

            Assert.Warn("Not solved");
        }
    }
}