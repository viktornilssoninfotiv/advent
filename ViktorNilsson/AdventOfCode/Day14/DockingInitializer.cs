namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class DockingInitializer : InputDataHandler
    {
        public static int[] Initialize(int[] initial, string[] instructionArray)
        {
            string currentBitMask;
            long address;
            long value;
            foreach (var instruction in instructionArray)
            {
                var splitCmd = Regex.Split(instruction, " = ");
                string cmd = splitCmd[0];
                string cmdValue = splitCmd[1];

                if (cmd.Contains("mask"))
                {
                    currentBitMask = cmdValue;
                }
                else
                {
                    address = long.Parse(Regex.Match(cmd, @"[0-9]+").ToString());
                    value = long.Parse(Regex.Match(cmdValue, @"[0-9]+").ToString());
                }
            }

            return initial;
        }
    }
}