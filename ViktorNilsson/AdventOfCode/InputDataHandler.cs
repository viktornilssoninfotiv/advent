using System;
using System.IO;

namespace TestAdventOfCode
{
    public class InputDataHandler
    {

        public static string[] ReadFileAsArray(string FilePath)
        {
            string fileContent = File.ReadAllText(FilePath);
            string[] fileRows = fileContent.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return fileRows;
        }
    }
}