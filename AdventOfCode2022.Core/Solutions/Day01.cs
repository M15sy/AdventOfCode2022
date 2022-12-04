using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/1</c>.
    /// </summary>
    public sealed class Day01 : ISolution
    {
        private static readonly IEnumerable<int> Calories =
            DoubleNewLine.Split(Inputs.Day01)
            .Select((elf) =>
                NewLine.Split(elf)
                       .Where(it => !NewLine.IsMatch(it) && !string.IsNullOrEmpty(it))
                       .Aggregate(0, (calories, snack) => calories + int.Parse(snack)));

        /// <inheritdoc/>
        public string PuzzleName => "--- Day 1: Calorie Counting ---";

        /// <inheritdoc/>
        public string SolvePart1() => Calories.Max().ToString();

        /// <inheritdoc/>
        public string SolvePart2() => Calories.OrderDescending().Take(3).Sum().ToString();
    }
}
