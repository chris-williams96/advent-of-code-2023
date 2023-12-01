using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.DayOne
{
    internal class Solution
    {
        public static void QuestionOne()
        {
            var regex = @"\d";

            Console.WriteLine(Solve(regex));
        }

        public static void QuestionTwo()
        {
            var regex = @"\d|one|two|three|four|five|six|seven|eight|nine";

            Console.WriteLine(Solve(regex));
        }

        private static int Solve(string regex)
        {
            var lines = File.ReadAllLines(@"DayOne\data.txt");
            int answer = 0;

            foreach (var line in lines)
            {
                var first = Regex.Match(line, regex).Value;
                var last = Regex.Match(line, regex, RegexOptions.RightToLeft).Value;
                var final = WordToNumber(first) + WordToNumber(last);
                answer += int.Parse(final);
            }

            return answer;
        }

        private static string WordToNumber(string s)
        {
            return s.ToLower() switch
            {
                "one" => "1",
                "two" => "2",
                "three" => "3",
                "four" => "4",
                "five" => "5",
                "six" => "6",
                "seven" => "7",
                "eight" => "8",
                "nine" => "9",
                _ => s,
            };
        }
    }
}
