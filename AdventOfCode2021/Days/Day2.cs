using System;
using AdventOfCode2021.Core;
using AdventOfCode2021.Helpers;

namespace AdventOfCode2021.Days
{
    /// <summary>
    /// https://adventofcode.com/2021/day/2
    /// </summary>
    public static class Day2
    {
        public static void Dive()
        {
            var course = FileReader.ReadCourseFromFile("day2");
            if (course == null)
                return;
            
            var start = new Location
            {
                Depth = 0,
                HorizontalPosition = 0
            };

            var finish = course.SimulateCourse(start, false);
            Console.WriteLine($"[#02a] Dive aimless : arrival code = {finish.HorizontalPosition} x {finish.Depth} = {finish.HorizontalPosition * finish.Depth}");
        }

        public static void DiveWithAim()
        {
            var course = FileReader.ReadCourseFromFile("day2");
            if (course == null)
                return;
            
            var start = new Location
            {
                Depth = 0,
                HorizontalPosition = 0
            };

            var finish = course.SimulateCourse(start, true);
            Console.WriteLine($"[#02b] Dive with aim : arrival code = {finish.HorizontalPosition} x {finish.Depth} = {finish.HorizontalPosition * finish.Depth}");
        }
    }
}