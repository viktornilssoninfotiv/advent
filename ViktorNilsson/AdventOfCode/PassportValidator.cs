using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TestAdventOfCode
{
    public class PassportValidator
    {
        private static List<string> passportValidKeys = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };
        public static string[] GetInputData(string filePath)
        {
            string[] rawPassports = InputDataHandler.ReadFileAsArray(filePath, "\r\n\r\n");
            return rawPassports;
        }

        public static Dictionary<string, string> ParseRawPassport(string rawPassport)
        {
            Dictionary<string, string> parsedPassport = new Dictionary<string, string>();
            string[] keysAndValuesRaw = Regex.Split(rawPassport, @"\s+");
            foreach (string keyValuePair in keysAndValuesRaw)
            {
                string[] keyValuePairSplit = keyValuePair.Split(':');
                parsedPassport.Add(keyValuePairSplit[0], keyValuePairSplit[1]);
            }

            return parsedPassport;
        }

        public static bool ValidatePassport(Dictionary<string, string> parsedPassport)
        {
            //bool isEqual = Enumerable.SequenceEqual(parsedPassport.Keys.OrderBy(e => e), y.OrderBy(e => e));

            bool passportIsValid;

            // Valid password
            // Lazy solution that doesn't verify the name of the fields
            // Identify the special case where only cid is missing
            if (!parsedPassport.ContainsKey("cid") && parsedPassport.Keys.Count == 7) passportIsValid = true;
            else if (parsedPassport.Keys.Count == 8) passportIsValid = true;
            else passportIsValid = false;

            return passportIsValid;
        }

        public static int CountValidPassports(string[] rawPassports)
        {
            int noOfValidPasswords = 0;
            foreach (string rawPassport in rawPassports)
            {
                Dictionary<string, string> parsedPassport = PassportValidator.ParseRawPassport(rawPassport);
                if (PassportValidator.ValidatePassport(parsedPassport))
                {
                    noOfValidPasswords++;
                }
            }

            return noOfValidPasswords;
        }
    }
}