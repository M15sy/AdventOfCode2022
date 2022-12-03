using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    public sealed class Day01 : ISolution
    {
        public string QuestionName => "--- Day 1: Calorie Counting ---";

        private static readonly IEnumerable<int> calories =
            DOUBLE_NEW_LINE.Split(Inputs.Day01)
            .Select((elf) =>
                NEW_LINE.Split(elf)
                       .Where(it => !NEW_LINE.IsMatch(it) && !string.IsNullOrEmpty(it))
                       .Aggregate(0, (calories, snack) => calories + int.Parse(snack))
            );

        public string SolvePart1() => calories.Max().ToString();

        public string SolvePart2() => calories.OrderDescending().Take(3).Sum().ToString();
    }
}
