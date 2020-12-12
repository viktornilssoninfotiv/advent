namespace AdventOfCode
{
    using System.Collections.Generic;
    using NUnit.Framework;

    //[TestFixture(12)]
    public class TestNavigator
    {
        private const string DayPath = @"../../../../AdventOfCode/Day12/";
        private const string FilePathInputData = DayPath + "InputData.txt";
        private const string FilePathTestData = DayPath + "TestData.txt";
        private string[] testData;
        private string[] inputData;

        [SetUp]
        public void Setup()
        {
            //var classUnderTest = new Navigator();
            this.testData = Navigator.ReadFileAsArray(FilePathTestData);
            this.inputData = Navigator.ReadFileAsArray(FilePathInputData);
        }

        [Test]
        public void TestGetInputData()
        {
            var localTestData = this.testData;
            Assert.AreEqual(10, localTestData.GetLength(0));
            Assert.AreEqual(10, localTestData.GetLength(0));
        }


        [Test]
        public void FindAnswerDayElevenPuzzleOne()
        {
            //var seats = Navigator.Simulate(this.inputData);
            //Assert.AreEqual(2334, 1);
            Assert.Warn("Not solved");
        }

        [Test]
        public void FindAnswerDayElevenPuzzleTwo()
        {
            Assert.Warn("Not solved");


        }
    }
}