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
            this.testData = Navigator.ReadFileAsArray(FilePathTestData);
            this.inputData = Navigator.ReadFileAsArray(FilePathInputData);
        }

        [Test]
        public void TestGetInputData()
        {
            var localTestData = this.testData;
            Assert.AreEqual(5, localTestData.GetLength(0));
        }

        [TestCase("F10", 0, 0, -90, 10, 0, -90)]
        public void TestNavigate(string instruction, int initialLat, int initialLong, int initialAngle, int expectedLong, int expectedLat, int expectedAngle)
        {

            var pos = Navigator.Navigate(instruction, initialLat, initialLong, initialAngle);
            Assert.AreEqual(expectedLat, pos.latitude);
            Assert.AreEqual(expectedLong, pos.longitude);
            Assert.AreEqual(expectedAngle, pos.angle);
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