using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestAdventOfCode
{
    public class TestLuggageProcessor
    {
        private const string FilePathInputData = "../../../../AdventOfCode/InputData/DaySevenInput.txt";
        private const string FilePathTestData = "../../../TestData/DaySevenTestData.txt";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetInputData()
        {
            string[] groupAnswers = LuggageProcessor.GetInputData(FilePathTestData);
            Assert.AreEqual(9, groupAnswers.GetLength(0));
        }

        [TestCase(0, "light red", new string[] { "bright white", "muted yellow" })]
        [TestCase(1, "dark orange", new string[] { "bright white", "muted yellow" })]
        [TestCase(2, "bright white", new string[] { "shiny gold" })]
        [TestCase(7, "faded blue", new string[] { "" })]
        public void TestParseLuggageRule(int iTestData, string colorKey, string[] colorValues)
        {
            Dictionary<string, string[]> expectedAnswer = new Dictionary<string, string[]>();
            expectedAnswer[colorKey] = colorValues;

            string[] rawData = LuggageProcessor.GetInputData(FilePathTestData);
            Dictionary<string, string[]> parsedRule = LuggageProcessor.ParseLuggageRule(rawData[iTestData]);
            Assert.AreEqual(expectedAnswer, parsedRule);
        }

        [Test]
        public void TestCreateRuleBook()
        {
            string[] rawData = LuggageProcessor.GetInputData(FilePathTestData);
            Dictionary<string, string[]> ruleBook = LuggageProcessor.CreateRuleBook(rawData);
            Assert.AreEqual(9, ruleBook.Keys.Count);
        }

        [TestCase("shiny gold", "bright white")]
        [TestCase("shiny gold", "muted yellow")]
        [TestCase("shiny gold", "dark orange")]
        [TestCase("shiny gold", "light red")]
        [TestCase("not existing", "")]
        public void TestGetBagOptionsContains(string bagColor, string expectedColor)
        {
            string[] rawData = LuggageProcessor.GetInputData(FilePathTestData);
            Dictionary<string, string[]> ruleBook = LuggageProcessor.CreateRuleBook(rawData);
            List<string> bagOptions = LuggageProcessor.GetBagOptions(ruleBook, bagColor);
            Assert.Contains(expectedColor, bagOptions);
        }

        [TestCase("shiny gold", new string[] { "bright white", "muted yellow", "dark orange", "light red" })]
        [TestCase("not existing", 0)]
        public void TestGetBagOptionsEquality(string bagColor, List<string> expectedColors)
        {
            string[] rawData = LuggageProcessor.GetInputData(FilePathTestData);
            Dictionary<string, string[]> ruleBook = LuggageProcessor.CreateRuleBook(rawData);
            List<string> bagOptions = LuggageProcessor.GetBagOptions(ruleBook, bagColor);
            Assert.AreEqual(expectedColors, bagOptions);
        }

        [TestCase("shiny gold", 4)]
        [TestCase("not existing", 0)]
        public void TestCountBagOptions(string bagColor, int exptectedOptions)
        {
            string[] rawData = LuggageProcessor.GetInputData(FilePathTestData);
            Dictionary<string, string[]> ruleBook = LuggageProcessor.CreateRuleBook(rawData);
            int numberOfBagOptions = LuggageProcessor.CountBagOptions(ruleBook, bagColor);
            Assert.AreEqual(exptectedOptions, numberOfBagOptions);
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