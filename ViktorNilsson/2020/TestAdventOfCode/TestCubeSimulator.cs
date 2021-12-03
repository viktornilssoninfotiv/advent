namespace AdventOfCode
{
    using System.Collections.Generic;
    using NUnit.Framework;

    public class TestCubeSimulator
    {
        private const string DayPath = @"../../../../AdventOfCode/Day17/";
        private const string FilePathInputData = DayPath + "InputData.txt";
        private const string FilePathTestData = DayPath + "TestData.txt";
        private char[,] testData;
        private char[,] inputData;

        [SetUp]
        public void Setup()
        {
            var cubesim = new CubeSimulator();
            this.testData = cubesim.GetInputDataMap(FilePathTestData);
            this.inputData = cubesim.GetInputDataMap(FilePathInputData);
        }

        [Test]
        public void TestGetInputData()
        {
            var localTestData = this.testData;
            Assert.AreEqual(3, localTestData.GetLength(0));
            Assert.AreEqual(3, localTestData.GetLength(1));
        }

        [Test]
        public void TestGetInitialState()
        {
            char[,,] initialState = CubeSimulator.GetInitialState(this.testData);
            Assert.AreEqual(3, initialState.GetLength(0));
            Assert.AreEqual(3, initialState.GetLength(1));
            Assert.AreEqual(3, initialState.GetLength(2));
            Assert.AreEqual('.', initialState[0, 0, 0]);
            Assert.AreEqual('#', initialState[0, 1, 0]);
        }

        [TestCase(0, new int[] { 0, 1, 0 })]
        [TestCase(1, new int[] { 1, 2, 0 })]
        [TestCase(2, new int[] { 2, 0, 0 })]
        [TestCase(3, new int[] { 2, 1, 0 })]
        [TestCase(4, new int[] { 2, 2, 0 })]
        public void TestGetActiveInitialStates(int iCube, int[] expectedCoordinates)
        {
            List<int[]> activeCubes = CubeSimulator.GetActiveCubes(this.testData);
            Assert.AreEqual(5, activeCubes.Count);
            Assert.AreEqual(expectedCoordinates, activeCubes[iCube]);
        }

        [TestCase(1, 11)]
        [TestCase(2, 21)]
        [TestCase(3, 38)]
        [TestCase(6, 112)]
        public void TestSimulate(int simulationSteps, int expectedActive)
        {
            List<int[]> activeCubes = CubeSimulator.Simulate(this.testData, simulationSteps);
            Assert.AreEqual(expectedActive, activeCubes.Count);
        }

        [Test]
        public void TestGetSurroundingActiveCubes()
        {
            List<int[]> activeCubes = CubeSimulator.GetActiveCubes(this.testData);
            int noOfActive = CubeSimulator.GetSurroundingActive(activeCubes[0], activeCubes);
            Assert.AreEqual(1, noOfActive);
        }

        [Test]
        public void TestGetSurroundingInctiveCubes()
        {
            List<int[]> activeCubes = CubeSimulator.GetActiveCubes(this.testData);
            List<int[]> inactiveCubes = CubeSimulator.GetSurroundingInactive(activeCubes);
            Assert.AreEqual(61, inactiveCubes.Count);
        }

        [Test]
        public void FindAnswerDaySeventeenPuzzleOne()
        {
            List<int[]> activeCubes = CubeSimulator.Simulate(this.inputData, 6);
            Assert.AreEqual(448, activeCubes.Count);
        }

        [Test]
        public void FindAnswerDayElevenPuzzleTwo()
        {
            Assert.Warn("Not solved");
        }
    }
}