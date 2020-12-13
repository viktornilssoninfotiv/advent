namespace AdventOfCode
{
    using System.Numerics;
    using NUnit.Framework;

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

        [TestCase("E10", 0, 0, -90, 10, 0, -90)]
        [TestCase("W10", 0, 0, -90, -10, 0, -90)]
        [TestCase("N10", 0, 0, -90, 0, 10, -90)]
        [TestCase("S10", 0, 0, -90, 0, -10, -90)]
        [TestCase("F10", 0, 0, 90, 10, 0, 90)]
        [TestCase("F10", 10, 10, 90, 20, 10, 90)]
        public void TestNavigate(string instruction, int initialLat, int initialLong, float initialAngle, int expectedLat, int expectedLong, float expectedAngle)
        {
            var initialPos = new Quaternion(initialLat, initialLong, 0, Navigator.Deg2Rad(initialAngle));
            var updatedPos = Navigator.Navigate(instruction, initialPos);
            Assert.AreEqual(expectedLat, updatedPos.X);
            Assert.AreEqual(expectedLong, updatedPos.Y);
            Assert.AreEqual(expectedAngle, updatedPos.W);
            Assert.AreEqual(0, updatedPos.Z);
        }

        [Test]
        public void FindAnswerDayElevenPuzzleOne()
        {
            // var seats = Navigator.Simulate(this.inputData);
            // Assert.AreEqual(2334, 1);
            Assert.Warn("Not solved");
        }

        [Test]
        public void FindAnswerDayElevenPuzzleTwo()
        {
            Assert.Warn("Not solved");
        }
    }
}