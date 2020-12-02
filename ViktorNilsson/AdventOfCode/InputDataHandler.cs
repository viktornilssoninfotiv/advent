using System.IO;

namespace TestAdventOfCode
{
    public class InputDataHandler
    {

        public static string[] ReadFileAsArray(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            string[] fileRows = fileContent.Split('\n');
            return fileRows;
        }
    }
}