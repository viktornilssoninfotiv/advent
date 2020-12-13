namespace AdventOfCode
{
    using System;
    using NUnit.Framework;

    public class TestCustomsDeclarator
    {
        private const string FilePathInputData = "../../../../AdventOfCode/InputData/DaySixInput.txt";
        private const string FilePathTestData = "../../../TestData/DaySixTestData.txt";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetInputData()
        {
            string[] groupAnswers = CustomsDeclarator.GetInputData(FilePathTestData);
            Assert.AreEqual(5, groupAnswers.GetLength(0));

            // Assert.AreEqual("abc", groupAnswers[0]);
            // Assert.AreEqual("abc", groupAnswers[1]);
        }

        [TestCase(0, 3)]
        [TestCase(1, 3)]
        [TestCase(2, 3)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        public void TestCountAnswers(int iTestData, int expectedAnswers)
        {
            string[] rawData = CustomsDeclarator.GetInputData(FilePathTestData);
            int positiveAnswers = CustomsDeclarator.CountAnswers(rawData[iTestData]);
            Assert.AreEqual(expectedAnswers, positiveAnswers);
        }

        [Test]
        public void TestSumAnswers()
        {
            string[] rawData = CustomsDeclarator.GetInputData(FilePathTestData);
            int sumOfAnswers = CustomsDeclarator.SumAnswers(rawData);
            Assert.AreEqual(11, sumOfAnswers);
        }

        [Test]
        public void FindAnserDaySixPuzzleOne()
        {
            string[] rawData = CustomsDeclarator.GetInputData(FilePathInputData);
            int sumOfAnswers = CustomsDeclarator.SumAnswers(rawData);
            Console.WriteLine("Number of valid passports: " + sumOfAnswers);
            Assert.AreEqual(6630, sumOfAnswers);
        }

        [TestCase(0, 3)]
        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        public void TestCountConsensusAnswers(int iTestData, int expectedAnswers)
        {
            string[] rawData = CustomsDeclarator.GetInputData(FilePathTestData);
            int positiveAnswers = CustomsDeclarator.CountConsensusAnswers(rawData[iTestData]);
            Assert.AreEqual(expectedAnswers, positiveAnswers);
        }

        [Test]
        public void TestSumConsensusAnswers()
        {
            string[] rawData = CustomsDeclarator.GetInputData(FilePathTestData);
            int sumOfAnswers = CustomsDeclarator.SumConsensusAnswers(rawData);
            Assert.AreEqual(6, sumOfAnswers);
        }

        [Test]
        public void FindAnserDaySixPuzzleTwo()
        {
            string[] rawData = CustomsDeclarator.GetInputData(FilePathInputData);
            int sumOfAnswers = CustomsDeclarator.SumConsensusAnswers(rawData);
            Console.WriteLine("Number of valid passports: " + sumOfAnswers);
            Assert.AreEqual(3437, sumOfAnswers);
        }
    }
}