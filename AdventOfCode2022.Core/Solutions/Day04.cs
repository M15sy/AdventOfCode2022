using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/4</c>.
    /// </summary>
    public sealed class Day04 : SolutionBase
    {
        /// <inheritdoc/>
        public override string PuzzleName => "--- Day 4: Camp Cleanup ---";

        /// <inheritdoc/>
        protected override string InputFileName => "Day04";

        /// <inheritdoc/>
        public override string SolvePart1() =>
            this.Solve(pair => pair switch
            {
                var (e_1, e_2) when e_1.First() >= e_2.First() && e_1.Last() <= e_2.Last() => true,
                var (e_1, e_2) when e_2.First() >= e_1.First() && e_2.Last() <= e_1.Last() => true,
                _ => false
            });

        /// <inheritdoc/>
        public override string SolvePart2() => this.Solve(pair => pair.Item1.Intersect(pair.Item2).Any());

        private static IEnumerable<int> ParseAssignment(string input)
        {
            var parts = input.Split('-');
            var start = int.Parse(parts[0]);
            var count = int.Parse(parts[1]) - start + 1;
            return Enumerable.Range(start, count);
        }

        private string Solve(Func<(IEnumerable<int>, IEnumerable<int>), bool> pairPredicate) =>
            NewLine.Split(this.ReadInput()).Where(it => !NewLine.IsMatch(it))
            .Select(line =>
            {
                var assignments = line.Split(',');
                return (ParseAssignment(assignments[0]), ParseAssignment(assignments[1]));
            })
            .Where(pairPredicate)
            .Count()
            .ToString();
    }
}
