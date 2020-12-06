using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestAdventOfCode
{
    public class TestPassportValidator
    {
        private const string FilePathInputData = "../../../../AdventOfCode/InputData/DayFourInput.txt";
        private const string FilePathTestData = "../../../TestData/DayFourTestData.txt";
        private const string FilePathTestDataStrict = "../../../TestData/DayFourTestDataStrict.txt";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetInputData()
        {
            string[] rawPassports = PassportValidator.GetInputData(FilePathTestData);
            Assert.AreEqual(4, rawPassports.GetLength(0));
        }

        [Test]
        public void TestParsePassport()
        {
            string[] rawPassports = PassportValidator.GetInputData(FilePathTestData);
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
            string[] rawPassports = PassportValidator.GetInputData(FilePathTestData);
            Dictionary<string, string> parsedPassport = PassportValidator.ParseRawPassport(rawPassports[iTestDataPassport]);
            bool passportValid = PassportValidator.ValidatePassport(parsedPassport);
            Assert.AreEqual(expectedValid, passportValid);
        }

        [Test]
        public void TestCountValidPassports()
        {
            string[] rawPassports = PassportValidator.GetInputData(FilePathTestData);
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
            string[] rawPassports = PassportValidator.GetInputData(FilePathInputData);
            int nuOfValidPassports = PassportValidator.CountValidPassports(rawPassports);
            Console.WriteLine("Number of valid passports: " + nuOfValidPassports);
            Assert.AreEqual(228, nuOfValidPassports);
        }

        [Test]
        public void TestCountValidPassportsStrictValid()
        {
            string[] rawPassports = PassportValidator.GetInputData(FilePathTestDataStrict);
            int nuOfValidPassports = PassportValidator.CountValidPassportsStrict(rawPassports);
            Assert.AreEqual(4, nuOfValidPassports);
        }

        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(5, false)]
        [TestCase(6, false)]
        [TestCase(7, false)]
        public void TestValidatePassportStrict(int iTestDataPassport, bool expectedValid)
        {
            string[] rawPassports = PassportValidator.GetInputData(FilePathTestDataStrict);
            Dictionary<string, string> parsedPassport = PassportValidator.ParseRawPassport(rawPassports[iTestDataPassport]);
            bool passportValid = PassportValidator.ValidatePassportStrict(parsedPassport);
            Assert.AreEqual(expectedValid, passportValid);
        }

        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(5, false)]
        [TestCase(6, false)]
        [TestCase(7, false)]
        public void TestValidatePassportRegex(int iTestDataPassport, bool expectedValid)
        {
            string[] rawPassports = PassportValidator.GetInputData(FilePathTestDataStrict);
            Dictionary<string, string> parsedPassport = PassportValidator.ParseRawPassport(rawPassports[iTestDataPassport]);
            bool passportValid = PassportValidator.ValidatePassportRegex(parsedPassport);
            Assert.AreEqual(expectedValid, passportValid);
        }

        [Test]
        public void FindAnserDayFourPuzzleTwo()
        {
            string[] rawPassports = PassportValidator.GetInputData(FilePathInputData);
            int nuOfValidPassports = PassportValidator.CountValidPassportsStrict(rawPassports);
            Console.WriteLine("Number of valid passports: " + nuOfValidPassports);
            Assert.IsTrue(nuOfValidPassports < 176);
            Assert.AreEqual(185, nuOfValidPassports);
        }
    }
}