namespace AdventOfCode
{
    using System.Collections.Generic;
    using NUnit.Framework;

    public class TestSeatSimulator
    {
        private const string DayPath = @"../../../../AdventOfCode/Day11/";
        private const string FilePathInputData = DayPath + "InputData.txt";
        private const string FilePathTestData = DayPath + "TestData.txt";
        private char[,] testData;
        private char[,] inputData;

        [SetUp]
        public void Setup()
        {
            var seatSim = new SeatSimulator();
            this.testData = seatSim.GetInputDataMap(FilePathTestData);
            this.inputData = seatSim.GetInputDataMap(FilePathInputData);
        }

        [Test]
        public void TestGetInputData()
        {
            var localTestData = this.testData;
            Assert.AreEqual(10, localTestData.GetLength(0));
            Assert.AreEqual(10, localTestData.GetLength(1));
        }

        [Test]
        public void TestAdjacentSeats()
        {
            var seats = SeatSimulator.AdjacentSeats(this.testData, 0, 0);
            var expectedSeats = new List<char> { 'L', '.', 'L', 'L' };
            Assert.AreEqual(4, seats.Count);
            Assert.AreEqual(expectedSeats, seats);
        }

        [Test]
        public void TestCountSeats()
        {
            var seats = SeatSimulator.CountSeats(this.testData);
            Assert.AreEqual(0, seats.occupied);
            Assert.AreEqual(71, seats.free);
        }

        [TestCase(1, 71)]
        [TestCase(2, 20)]
        [TestCase(5, 37)]
        public void TestSimulate(int simulationSteps, int expectedOccupied)
        {
            var seats = SeatSimulator.Simulate(this.testData, simulationSteps);
            int expectedFree = 71 - expectedOccupied;
            Assert.AreEqual(expectedOccupied, seats.occupied);
            Assert.AreEqual(expectedFree, seats.free);
        }

        [Test]
        public void TestSimulateToSteadyState()
        {
            int expectedOccupied = 37;
            var seats = SeatSimulator.Simulate(this.testData);
            int expectedFree = 71 - expectedOccupied;
            Assert.AreEqual(expectedOccupied, seats.occupied);
            Assert.AreEqual(expectedFree, seats.free);
        }

        [Test]
        public void FindAnswerDayElevenPuzzleOne()
        {
            var seats = SeatSimulator.Simulate(this.inputData);
            Assert.AreEqual(2334, seats.occupied);
        }

        [Test]
        public void FindAnswerDayElevenPuzzleTwo()
        {
            Assert.Warn("Not solved");
        }
    }
}