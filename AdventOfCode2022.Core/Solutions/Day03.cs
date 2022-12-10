using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/3</c>.
    /// </summary>
    public sealed class Day03 : SolutionBase
    {
        private const string Priority = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <inheritdoc/>
        public override string PuzzleName => "--- Day 3: Rucksack Reorganization ---";

        /// <inheritdoc/>
        protected override string InputFileName => "Day03";

        private IEnumerable<string> Lines => NewLine.Split(this.ReadInput()).Where(it => !NewLine.IsMatch(it));

        /// <inheritdoc/>
        public override string SolvePart1() =>
            Solve(
                this.Lines
                .Select(line =>
                {
                    var mid = line.Length / 2;
                    return new string[2] { line[0..mid], line[mid..] };
                }));

        /// <inheritdoc/>
        public override string SolvePart2() =>
            Solve(
                this.Lines
                .Aggregate(new Stack<string?[]>(), (acc, cur) =>
                {
                    bool shouldPop = acc.Count > 0 && acc.Peek()[2] == null;
                    var group = shouldPop ? acc.Pop() : new string?[3] { null, null, null };
                    var index = group switch
                    {
                        [null, _, _] => 0,
                        [_, null, _] => 1,
                        _ => 2
                    };
                    group[index] = cur;
                    acc.Push(group);
                    return acc;
                }));

        private static string Solve(IEnumerable<string?[]> groups) =>
            groups.Select(group => GetPriority(group)).Sum().ToString();

        private static int GetPriority(params string?[] groups)
        {
            if (groups.Length < 2)
            {
                throw new ArgumentException("Expecting at least 2 groups of items.");
            }

            var first = groups[0];
            var rest = groups[1..];
            var commonItem = first?.First(c => rest.All(it => it is not null && it.Contains(c)));

            if (commonItem is null)
            {
                throw new ArgumentException("No common item found.");
            }

            return Priority.IndexOf((char)commonItem);
        }
    }
}
