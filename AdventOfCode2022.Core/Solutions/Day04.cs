using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/4</c>.
    /// </summary>
    public sealed class Day04 : ISolution
    {
        private static readonly IEnumerable<(IEnumerable<int>, IEnumerable<int>)> Pairs =
            NewLine.Split(Inputs.Day04).Where(it => !NewLine.IsMatch(it))
            .Select(line =>
            {
                var assignments = line.Split(',');
                return (ParseAssignment(assignments[0]), ParseAssignment(assignments[1]));
            });

        /// <inheritdoc/>
        public string PuzzleName => "--- Day 4: Camp Cleanup ---";

        /// <inheritdoc/>
        public string SolvePart1() =>
            Pairs.Where(pair => pair switch
            {
                var (e_1, e_2) when e_1.First() >= e_2.First() && e_1.Last() <= e_2.Last() => true,
                var (e_1, e_2) when e_2.First() >= e_1.First() && e_2.Last() <= e_1.Last() => true,
                _ => false
            })
            .Count()
            .ToString();

        /// <inheritdoc/>
        public string SolvePart2() =>
            Pairs.Where(pair => pair.Item1.Intersect(pair.Item2).Any()).Count().ToString();

        private static IEnumerable<int> ParseAssignment(string input)
        {
            var parts = input.Split('-');
            var start = int.Parse(parts[0]);
            var count = int.Parse(parts[1]) - start + 1;
            return Enumerable.Range(start, count);
        }
    }
}
