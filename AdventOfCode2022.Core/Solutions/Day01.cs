using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/1</c>.
    /// </summary>
    public sealed class Day01 : SolutionBase
    {
        private readonly IEnumerable<int> calories;

        /// <summary>
        /// Initializes a new instance of the <see cref="Day01"/> class.
        /// </summary>
        public Day01()
        {
            this.calories = DoubleNewLine.Split(this.ReadInput())
                .Select((elf) =>
                        NewLine.Split(elf)
                               .Where(it => !NewLine.IsMatch(it) && !string.IsNullOrEmpty(it))
                               .Aggregate(0, (calories, snack) => calories + int.Parse(snack)));
        }

        /// <inheritdoc/>
        public override string PuzzleName => "--- Day 1: Calorie Counting ---";

        /// <inheritdoc/>
        protected override string InputFileName => "Day01";

        /// <inheritdoc/>
        public override string SolvePart1() => this.calories.Max().ToString();

        /// <inheritdoc/>
        public override string SolvePart2() => this.calories.OrderDescending().Take(3).Sum().ToString();
    }
}
