using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestAdventOfCode
{
    public class PasswordPolicy
    {
        private string policyRaw;
        public int minOccurence, maxOccurence;
        public char policyLetter;
        private string password;

        public PasswordPolicy(string policyRaw)
        {
            this.policyRaw = policyRaw;
            string[] splitPolicy = policyRaw.Split();
            
            string[] occurencePolicy = splitPolicy[0].Split('-');
            this.minOccurence = Int32.Parse(occurencePolicy[0]);
            this.maxOccurence = Int32.Parse(occurencePolicy[1]);

            this.policyLetter = char.Parse(splitPolicy[1]);
        }

        public PasswordPolicy(string policyRaw, string password) : this(policyRaw)
        {
            this.password = password;
        }

        public static bool Check(int minOccurence, int maxOccurence, char policyLetter, string password)
        {
            int count = password.Count(f => f == policyLetter);

            if (count <= maxOccurence && count >= minOccurence)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool Check(string password)
        {
            return PasswordPolicy.Check(this.minOccurence, this.maxOccurence, this.policyLetter, password);
        }

        public static List<PasswordPolicy> GetInputData()
        {
            var policies = new List<PasswordPolicy>();
            // Specify folder since it can be run from elsewhere, e.g. unittest
            string[] policyPasswordList = InputDataHandler.ReadFileAsArray("../../../../AdventOfCode/DayTwoInput.txt");

            foreach (string unparsed in policyPasswordList)
            {
                string[] policyAndPassword = unparsed.Split(new string[] { ": " }, StringSplitOptions.None);
                policies.Add(new PasswordPolicy(policyAndPassword[0], policyAndPassword[1]));
            }
            return policies;
        }

        public static int CountValidPasswords(List<PasswordPolicy> passwordList)
        {
            int numberOfValidPasswords = 0;
            foreach (var passwordPolicy in passwordList)
            {
                if (passwordPolicy.Check(passwordPolicy.password))
                {
                    numberOfValidPasswords++;
                }
            }
            return numberOfValidPasswords;
        }

        public bool Check2(string password)
        {
            // Reinterpret the password policy
            // Decrement by 1 to convert from positiion to zero-indexed
            int indexA = this.minOccurence - 1;
            int indexB = this.maxOccurence - 1;

            // Exclusive or check
            if ((password[indexA] == this.policyLetter) ^ (password[indexB] == this.policyLetter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int CountValidPasswords2(List<PasswordPolicy> passwordList)
        {
            int numberOfValidPasswords = 0;
            foreach (var passwordPolicy in passwordList)
            {
                if (passwordPolicy.Check2(passwordPolicy.password))
                {
                    numberOfValidPasswords++;
                }
            }
            return numberOfValidPasswords;
        }
    }
}