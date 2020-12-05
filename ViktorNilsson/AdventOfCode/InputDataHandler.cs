using System;
using System.IO;

namespace TestAdventOfCode
{
    public class InputDataHandler
    {

        public static string[] ReadFileAsArray(string FilePath)
        {
            string fileContent = File.ReadAllText(FilePath);
            string[] fileRows = fileContent.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            return fileRows;
        }
    }
}