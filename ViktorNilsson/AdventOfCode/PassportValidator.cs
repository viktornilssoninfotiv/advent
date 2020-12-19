namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class PassportValidator
    {
        private const string FilePathPassportRulesRegex = "../../../../AdventOfCode/InputData/PassportRulesRegex.txt";
        private static readonly List<string> passportValidKeys = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };

        // private static Dictionary<string, string> passportRules = new Dictionary<string, string> {
        // { "byr", "" }, {"iyr" }, {"eyr" }, {"hgt" }, {"hcl" }, {"ecl" }, {"pid" }, {"cid" } };
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
            // bool isEqual = Enumerable.SequenceEqual(parsedPassport.Keys.OrderBy(e => e), y.OrderBy(e => e));
            bool passportIsValid;

            // Valid password
            // Lazy solution that doesn't verify the name of the fields
            // Identify the special case where only cid is missing
            if (!parsedPassport.ContainsKey("cid") && parsedPassport.Keys.Count == 7)
            {
                passportIsValid = true;
            }
            else if (parsedPassport.Keys.Count == 8)
            {
                passportIsValid = true;
            }
            else
            {
                passportIsValid = false;
            }

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

        public static int CountValidPassportsStrict(string[] rawPassports)
        {
            int noOfValidPasswords = 0;
            foreach (string rawPassport in rawPassports)
            {
                Dictionary<string, string> parsedPassport = PassportValidator.ParseRawPassport(rawPassport);
                if (PassportValidator.ValidatePassportStrict(parsedPassport))
                {
                    noOfValidPasswords++;
                }
            }

            return noOfValidPasswords;
        }

        public static bool ValidatePassportStrict(Dictionary<string, string> parsedPassport)
        {
            bool passportIsValid = true;

            // First test with the simple Validator
            if (!PassportValidator.ValidatePassport(parsedPassport))
            {
                passportIsValid = false;
            }

            // Second, invalidate by Regex
            else if (!PassportValidator.ValidatePassportRegex(parsedPassport))
            {
                passportIsValid = false;
            }

            return passportIsValid;
        }

        public static bool ValidatePassportRegex(Dictionary<string, string> parsedPassport)
        {
            bool passportIsValid = true;

            // Obtain the passport rules
            // TODO: This sghould only be new once. Maybe make into an instance variable?
            string[] rawPassportTemplateRegex = InputDataHandler.ReadFileAsArray(FilePathPassportRulesRegex, string.Empty);
            Dictionary<string, string> passportTemplateRegex = PassportValidator.ParseRawPassport(rawPassportTemplateRegex[0]);

            // Compare value for a kay with the allowed Regex expression
            // Loop over all template keys in case of an incomplete passport being supplied as argument
            foreach (KeyValuePair<string, string> currentFieldTemplate in passportTemplateRegex)
            {
                // Don't care about cid, skip to checking next field
                // TODO: Refactor to create all passport keys when reading the passport
                if (currentFieldTemplate.Key == "cid")
                {
                    continue;
                }

                string value = string.Empty;
                if (parsedPassport.TryGetValue(currentFieldTemplate.Key, out value))
                {
                    if (!Regex.IsMatch(value, currentFieldTemplate.Value))
                    {
                        passportIsValid = false;

                        // Console.WriteLine("Passport invalidated by: " + currentFieldTemplate.Key + ":" + value);
                    }
                }
                else
                {
                    // If a passport doesn't include the template key it is atomatically invalid
                    // TODO: Handle cid
                    // TODO: Refactor the simple invalidator to use this method?
                    passportIsValid = false;
                }
            }

            return passportIsValid;
        }
    }
}