using AdventOfCode2021.Days;
using System;

namespace AdventOfCode2021
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Day1.SonarSweep();                          // 1527
            Day1.SonarSweep_Windowed();                 // 1575

            Day2.Dive();                                // 1480518
            Day2.DiveWithAim();                         // 1282809906

            Day3.DecodeBinaryPowerConsumption();        // 3923414
            Day3.DecodeBinaryLifeSupport();             // 5852595

            Day4.PlayFirstBingo();                      // 25410
            Day4.PlayLastBingo();                       // 2730

            Day5.ComputePartialVenture();                // 4993
            Day5.ComputeFullVenture();                   // 21101

            Day6.SimulateLanternFishes();                // 343441
            Day6.SimulateLanternFishes_Grouped();        // 1569108373832

            Day7.AlignCrabs_Linear();                    // 336701
            Day7.AlignCrabs_Gradual();                   // 95167302

            Day8.ReadDigits_Partial();                   // 383
            Day8.ReadDigits_Complete();                  // 998900

            Console.ReadKey(true);
        }
    }
}