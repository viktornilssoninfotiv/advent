using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestAdventOfCode
{
    public class TestPasswordPolicy
    {
        private const string PuzzleFilePath = "../../../../AdventOfCode/InputData/DayTwoInput.txt";

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 1, 'a', "aa", false)]
        [TestCase(1, 2, 'a', "aa", true)]
        [TestCase(1, 2, 'a', "aaa", false)]
        [TestCase(2, 6, 'w', "wwaa", true)]
        [TestCase(2, 6, 'w', "wwwwwwwwwwwwwaa", false)]
        public void TestPasswordPolicyCheck(int minOccurence, int maxOccurence, char policyLetter, string password, bool expectedValid)
        {
            bool passwordValid = PasswordPolicy.Check(minOccurence, maxOccurence, policyLetter, password);

            Assert.AreEqual(passwordValid, expectedValid);
        }

        [Test]
        public void TestParsePasswordPolicy()
        {
            string policyRaw = "2-6 w";
            PasswordPolicy policy = new PasswordPolicy(policyRaw);

            Assert.AreEqual(2, policy.minOccurence);
            Assert.AreEqual(6, policy.maxOccurence);
            Assert.AreEqual('w', policy.policyLetter);
        }

        [TestCase("2-6 w", "ss", false)]
        [TestCase("2-6 w", "wwwss", true)]
        public void TestPasswordPolicySelfCheck(string policyRaw, string password, bool expectedValid)
        {
            PasswordPolicy policy = new PasswordPolicy(policyRaw);

            bool valid = policy.Check(password);
            Assert.AreEqual(expectedValid, valid);
        }

        [Test]
        public void TestGetInputData()
        {
            List<PasswordPolicy> passwordList = PasswordPolicy.GetInputData(PuzzleFilePath);
            Assert.AreEqual(1000, passwordList.Count());
        }

        [Test]
        public void TestCountValidPasswords()
        {
            var passwordList = new List<PasswordPolicy>();
            passwordList.Add(new PasswordPolicy("2-6 w", "wkwwwfwwpvw"));

            int numberOfValidPasswords = PasswordPolicy.CountValidPasswords(passwordList);
            Assert.AreEqual(0, numberOfValidPasswords);
        }

        [Test]
        public void FindAnswerDayTwoPuzzleOne()
        {
            List<PasswordPolicy> passwordList = PasswordPolicy.GetInputData(PuzzleFilePath);

            int numberOfValidPasswords = PasswordPolicy.CountValidPasswords(passwordList);
            Console.WriteLine(numberOfValidPasswords);
            Assert.AreEqual(536, numberOfValidPasswords);
        }

        [TestCase("1-3 a", "abcde", true)]
        [TestCase("1-3 b", "cdefg", false)]
        [TestCase("2-9 c", "ccccccccc", false)]
        [TestCase("2-9 c", "ccccccccc", false)]
        public void TestPasswordPolicySelfCheck2(string policyRaw, string password, bool expectedValid)
        {
            PasswordPolicy policy = new PasswordPolicy(policyRaw);

            bool valid = policy.Check2(password);
            Assert.AreEqual(expectedValid, valid);
        }

        [Test]
        public void FindAnswerDayTwoPuzzleTwo()
        {
            List<PasswordPolicy> passwordList = PasswordPolicy.GetInputData(PuzzleFilePath);

            int numberOfValidPasswords = PasswordPolicy.CountValidPasswords2(passwordList);
            Console.WriteLine(numberOfValidPasswords);
            Assert.AreEqual(558, numberOfValidPasswords);
        }
    }
}