namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.Linq;

    public class AdapterConnector
    {
        public static List<int> GetInputData(string filePath)
        {
            var inputData = new List<int>();
            string[] inputDataRaw = InputDataHandler.ReadFileAsArray(filePath);

            foreach (var s in inputDataRaw)
            {
                inputData.Add(int.Parse(s));
            }

            inputData.Sort();

            return inputData;
        }

        public static (int one, int two, int three) Connect(List<int> adapterList)
        {
            int one = 0;
            int two = 0;
            int three = 0;
            adapterList.Sort();

            // Add the outlet which is 0 jolt
            adapterList.Insert(0, 0);

            // Add the device which is 3 higher than max
            adapterList.Add(adapterList.Last() + 3);
            for (int iAdapter = 1; iAdapter < adapterList.Count; iAdapter++)
            {
                switch (adapterList[iAdapter] - adapterList[iAdapter - 1])
                {
                    case 1:
                        one++;
                        break;
                    case 2:
                        two++;
                        break;
                    case 3:
                        three++;
                        break;
                }
            }

            return (one, two, three);
        }
    }
}