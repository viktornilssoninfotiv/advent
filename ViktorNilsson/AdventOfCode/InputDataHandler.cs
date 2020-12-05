using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TestAdventOfCode
{
    public class InputDataHandler
    {

        public static string[] ReadFileAsArray(string FilePath, string dataSplit = "\r\n")
        {
            string fileContent = File.ReadAllText(FilePath);
            // string[] fileRows = Regex.Split(fileContent, @"\s+");
            string[] fileRows = fileContent.Split(new string[] { dataSplit }, StringSplitOptions.None);
            return fileRows;
        }
    }
}