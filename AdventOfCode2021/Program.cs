using AdventOfCode2021.Days;

namespace AdventOfCode2021
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Day1.SonarSweep();                   // 1527
            Day1.SonarSweep_Windowed();          // 1575

            Day2.Dive();                         // 1480518
            Day2.DiveWithAim();                  // 1282809906

            Day3.DecodeBinaryPowerConsumption(); // 3923414
            Day3.DecodeBinaryLifeSupport();      // 5852595

            Day4.PlayFirstBingo();               // 25410
            Day4.PlayLastBingo();                // 2730

            Day5.ComputeVenture();
        }
    }
}