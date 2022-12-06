using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/6</c>.
    /// </summary>
    public sealed class Day06 : SolutionBase
    {
        /// <inheritdoc/>
        public override string PuzzleName => "--- Day 6: Tuning Trouble ---";

        /// <inheritdoc/>
        protected override string InputFileName => "Day06";

        private string Input => this.ReadInput();

        /// <inheritdoc/>
        public override string SolvePart1() => this.Solve(4);

        /// <inheritdoc/>
        public override string SolvePart2() => this.Solve(14);

        private string Solve(int distinct)
        {
            for (var i = distinct; i < this.Input.Length; i++)
            {
                var substring = this.Input.Substring(i - distinct, distinct);
                var set = substring.ToHashSet();
                if (substring.Length == set.Count())
                {
                    return i.ToString();
                }
            }

            return $@"The input does not contain {distinct} characters.";
        }
    }
}
