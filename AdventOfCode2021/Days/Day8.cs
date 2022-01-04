using AdventOfCode2021.Core.Display;
using AdventOfCode2021.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Days
{
    /// <summary>
    /// https://adventofcode.com/2021/day/8
    /// </summary>
    public static class Day8
    { 
        private static SevenSegmentDisplay[] GetTestData()
        {
            // Counting only 1, 4, 7 and 8, expected result is: 26
            return new SevenSegmentDisplay[]
            {
                new SevenSegmentDisplay(
                    new List<string>() { "be", "cfbegad", "cbdgef", "fgaecd", "cgeb", "fdcge", "agebfd", "fecdb", "fabcd", "edb" }, 
                    new List<string>() { "fdgacbe", "cefdb", "cefbgd", "gcbe" }),
                new SevenSegmentDisplay(
                    new List<string>() { "edbfga", "begcd", "cbg", "gc", "gcadebf", "fbgde", "acbgfd", "abcde", "gfcbed", "gfec" }, 
                    new List<string>() { "fcgedb", "cgb", "dgebacf", "gc" }),
                new SevenSegmentDisplay(
                    new List<string>() { "fgaebd", "cg", "bdaec", "gdafb", "agbcfd", "gdcbef", "bgcad", "gfac", "gcb", "cdgabef" }, 
                    new List<string>() { "cg", "cg", "fdcagb", "cbg" }),
                new SevenSegmentDisplay(
                    new List<string>() { "fbegcd", "cbd", "adcefb", "dageb", "afcb", "bc", "aefdc", "ecdab", "fgdeca", "fcdbega" }, 
                    new List<string>() { "efabcd", "cedba", "gadfec", "cb" }),
                new SevenSegmentDisplay(
                    new List<string>() { "aecbfdg", "fbg", "gf", "bafeg", "dbefa", "fcge", "gcbea", "fcaegb", "dgceab", "fcbdga" }, 
                    new List<string>() { "gecf", "egdcabf", "bgf", "bfgea" }),
                new SevenSegmentDisplay(
                    new List<string>() { "fgeab", "ca", "afcebg", "bdacfeg", "cfaedg", "gcfdb", "baec", "bfadeg", "bafgc", "acf" }, 
                    new List<string>() { "gebdcfa", "ecba", "ca", "fadegcb" }),
                new SevenSegmentDisplay(
                    new List<string>() { "dbcfg", "fgd", "bdegcaf", "fgec", "aegbdf", "ecdfab", "fbedc", "dacgb", "gdcebf", "gf" }, 
                    new List<string>() { "cefg", "dcbef", "fcge", "gbcadfe" }),
                new SevenSegmentDisplay(
                    new List<string>() { "bdfegc", "cbegaf", "gecbf", "dfcage", "bdacg", "ed", "bedf", "ced", "adcbefg", "gebcd" }, 
                    new List<string>() { "ed", "bcgafe", "cdgba", "cbgef" }),
                new SevenSegmentDisplay(
                    new List<string>() { "egadfb", "cdbfeg", "cegd", "fecab", "cgb", "gbdefca", "cg", "fgcdab", "egfdb", "bfceg" }, 
                    new List<string>() { "gbdfcae", "bgc", "cg", "cgb" }),
                new SevenSegmentDisplay(
                    new List<string>() { "gcafb", "gcf", "dcaebfg", "ecagb", "gf", "abcdeg", "gaef", "cafbge", "fdbac", "fegbdc" }, 
                    new List<string>() { "fgae", "cfgab", "fg", "bagce" })
            };
        }

        public static void ReadDigits_Partial()
        {
            var sevSegDisplays = FileReader.ReadSevenSegmentDisplaysFromFile("day8");
            //var sevSegDisplays = GetTestData();

            // 1: two signals
            var oneCount = sevSegDisplays.SelectMany(d => d.ScrambledOutputs).Count(o => o.VisibleSegmentCount == 2);
            // 4: four signals
            var fourCount = sevSegDisplays.SelectMany(d => d.ScrambledOutputs).Count(o => o.VisibleSegmentCount == 4);
            // 7: three signals
            var sevenCount = sevSegDisplays.SelectMany(d => d.ScrambledOutputs).Count(o => o.VisibleSegmentCount == 3);
            // 8: seven signals
            var eightCount = sevSegDisplays.SelectMany(d => d.ScrambledOutputs).Count(o => o.VisibleSegmentCount == 7);
            var totalCount = oneCount + fourCount + sevenCount + eightCount;

            Console.WriteLine($"[#08a] Partial Seven-Segment Read : 1/4/7/8 numbers count = {oneCount} + {fourCount} + {sevenCount} + {eightCount} = {totalCount}");
        }
    }
}
