using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class TestEncoder
    {
        private const string Day = "Nine";
        private const string FilePathInputData = "../../../../AdventOfCode/InputData/Day" + Day + "Input.txt";
        private const string FilePathInputData2 = "../../../../AdventOfCode/InputData/Day" + Day + "Input2.txt";
        private const string FilePathTestData = "../../../TestData/Day" + Day + "TestData.txt";
        private List<long> testData;
        private List<long> inputData;

        [SetUp]
        public void Setup()
        {
            this.testData = Encoder.GetInputData(FilePathTestData);
            this.inputData = Encoder.GetInputData(FilePathInputData);
        }

        [Test]
        public void TestGetInputData()
        {
            var localTestData = this.testData;
            Assert.AreEqual(20, localTestData.Count);
            Assert.AreEqual(35, localTestData[0]);
        }

        [Test]
        public void TestFindWeakness()
        {
            int preambleLength = 5;
            var weakness = Encoder.FindWeakness(this.testData, preambleLength);
            Assert.AreEqual(127, weakness.num);
        }

        [Test]
        public void TestFindSums()
        {
            int preambleLength = 5;
            List<long> sum = Encoder.FindSums(new List<long> { 1, 2, 3 });
            Assert.AreEqual(3, sum.Count);
            Assert.AreEqual(new List<int> { 3, 4, 5 }, sum);
        }

        [Test]
        public void FindAnswerDayNinePuzzleOne()
        {
            int preambleLength = 25;
            var weakness = Encoder.FindWeakness(this.inputData, preambleLength);
            Assert.Contains(weakness.num, this.inputData);
            Assert.AreEqual(248131121, weakness.num);
        }

        [Test]
        public void TestFindSumSet()
        {
            long sumToFind = 127;
            List<long> set = Encoder.FindSumSet(this.testData, sumToFind);
            Assert.AreEqual(4, set.Count);
            Assert.AreEqual(new List<long> { 15, 25, 40, 47 }, set);
        }

        [Test]
        public void FindAnswerDayNinePuzzleTwo()
        {
            var sumToFind = Encoder.FindWeakness(this.inputData, 25);
            List<long> set = Encoder.FindSumSet(sumToFind.set, sumToFind.num);
            Assert.AreEqual(4, set.Count);
            Console.WriteLine("Smallest: " + set[0] + " Largest: " + set[set.Count]);
            long weaknessSum = set[0] + set[set.Count];
            Console.WriteLine("Weakness sum: " );

        }
    }
}