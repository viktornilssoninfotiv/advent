using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestAdventOfCode
{
    public class TestPassportValidator
    {
        private const string PuzzleFilePath = "../../../../AdventOfCode/InputData/DayFourInput.txt";
        private const string TestDataFilePath = "../../../TestData/DayFourTestData.txt";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetInputData()
        {
            string[] rawPassports = PassportValidator.GetInputData(TestDataFilePath);
            Assert.AreEqual(4, rawPassports.GetLength(0));
        }

        [Test]
        public void TestParsePassport()
        {
            string[] rawPassports = PassportValidator.GetInputData(TestDataFilePath);
            Dictionary<string, string> parsedPassport = PassportValidator.ParseRawPassport(rawPassports[0]);
            Assert.AreEqual(8, parsedPassport.Count);
            Assert.IsTrue(parsedPassport.ContainsKey("ecl"));
            Assert.IsTrue(parsedPassport.ContainsValue("gry"));
        }

        [TestCase(0, true, TestName = "Valid Passport")]
        [TestCase(1, false, TestName = "Invalid Passport")]
        [TestCase(2, true, TestName = "Valid Passport missing cid")]
        [TestCase(3, false, TestName = "Valid Passport missing multiple fields")]
        public void TestValidatePassport(int iTestDataPassport, bool expectedValid)
        {
            string[] rawPassports = PassportValidator.GetInputData(TestDataFilePath);
            Dictionary<string, string> parsedPassport = PassportValidator.ParseRawPassport(rawPassports[iTestDataPassport]);
            bool passportValid = PassportValidator.ValidatePassport(parsedPassport);
            Assert.AreEqual(expectedValid, passportValid);
        }

        [Test]
        public void TestCountValidPassports()
        {
            string[] rawPassports = PassportValidator.GetInputData(TestDataFilePath);
            int nuOfValidPassports = PassportValidator.CountValidPassports(rawPassports);
            Assert.AreEqual(2, nuOfValidPassports);
        }

        [Test]
        public void TestCountValidPassportsEmpty()
        {
            string[] rawPassports = new string[] {"xx:yy"};
            int nuOfValidPassports = PassportValidator.CountValidPassports(rawPassports);
            Assert.AreEqual(0, nuOfValidPassports);
        }

        [Test]
        public void FindAnserDayFourPuzzleOne()
        {
            string[] rawPassports = PassportValidator.GetInputData(PuzzleFilePath);
            int nuOfValidPassports = PassportValidator.CountValidPassports(rawPassports);
            Console.WriteLine("Number of valid passports: " + nuOfValidPassports);
            Assert.AreEqual(228, nuOfValidPassports);
        }
    }
}