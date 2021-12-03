namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class DockingInitializer : InputDataHandler
    {
        public const long ArraySize = 68719476736;

        public static Dictionary<long, long> Initialize(Dictionary<long, long> initial, string[] instructionArray)
        {
            string tempBitMask;
            long currentBitMaskOr = 0;
            long currentBitMaskAnd = 2 ^ 63;
            long address;
            long value;
            foreach (var instruction in instructionArray)
            {
                var splitCmd = Regex.Split(instruction, " = ");
                string cmd = splitCmd[0];
                string cmdValue = splitCmd[1];

                if (cmd.Contains("mask"))
                {
                    // To force a 1 bit, do bitwise OR with a 1
                    // Replace all X with 0 to don't care
                    tempBitMask = cmdValue.Replace('X', '0');
                    currentBitMaskOr = Convert.ToInt64(tempBitMask, 2);

                    // To force a 0 bit, do bitwise AND with a 0
                    // Replace all X with 1 to don't care
                    tempBitMask = cmdValue.Replace('X', '1');
                    currentBitMaskAnd = Convert.ToInt64(tempBitMask, 2);
                }
                else
                {
                    address = long.Parse(Regex.Match(cmd, @"[0-9]+").ToString());
                    value = long.Parse(Regex.Match(cmdValue, @"[0-9]+").ToString());
                    initial[address] = (value & currentBitMaskAnd) | currentBitMaskOr;
                }
            }

            return initial;
        }

        public static long Sum(Dictionary<long, long> data)
        {
            long sum = 0;
            foreach (var keyValuePair in data)
            {
                sum += keyValuePair.Value;
            }
            return sum;
        }
    }
}