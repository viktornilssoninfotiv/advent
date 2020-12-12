using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class TestSeatSimulator
    {
        private const string Day = "Eleven";
        private const string FilePathInputData = "../../../../AdventOfCode/InputData/Day" + Day + "Input.txt";
        private const string FilePathInputData2 = "../../../../AdventOfCode/InputData/Day" + Day + "Input2.txt";
        private const string FilePathTestData = "../../../TestData/Day" + Day + "TestData.txt";
        private char[,] testData;
        private char[,] inputData;

        [SetUp]
        public void Setup()
        {
            var seatSim = new SeatSimulator();
            this.testData = seatSim.GetInputData(FilePathTestData);
            this.inputData = seatSim.GetInputData(FilePathInputData);
        }

        [Test]
        public void TestGetInputData()
        {
            var localTestData = this.testData;
            Assert.AreEqual(10, localTestData.GetLength(0));
            Assert.AreEqual(10, localTestData.GetLength(0));
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
            Assert.IsTrue(false);


        }
    }
}