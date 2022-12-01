using System.Text.RegularExpressions;

namespace AdventOfCode2022.Core
{
    public class Day01 : ISolution
    {
        public string QuestionName => "--- Day 1: Calorie Counting ---";

        private static readonly Regex newLine = new Regex("(\r\n|\r|\n)");
        private static readonly Regex doubleNewLine = new Regex("(\r\n|\r|\n){2}");

        private static readonly IOrderedEnumerable<int> calories =
            doubleNewLine.Split(Inputs.Day01)
            .Select((elf) =>
                newLine.Split(elf)
                       .Where(it => !newLine.IsMatch(it) && !string.IsNullOrEmpty(it))
                       .Aggregate(0, (a, c) => a + int.Parse(c))
            )
            .OrderDescending();

        public string SolvePart1() => calories.ElementAt(0).ToString();

        public string SolvePart2() => (
            calories.ElementAt(0) + calories.ElementAt(1) + calories.ElementAt(2)
            ).ToString();
    }
}
