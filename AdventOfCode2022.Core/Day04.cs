using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    public sealed class Day04 : ISolution
    {
        public string QuestionName => "--- Day 4: Camp Cleanup ---";

        private static IEnumerable<int> ParseAssignment(string input)
        {
            var parts = input.Split('-');
            var start = int.Parse(parts[0]);
            var count = int.Parse(parts[1]) - start + 1;
            return Enumerable.Range(start, count);
        }

        private static readonly IEnumerable<(IEnumerable<int>, IEnumerable<int>)> pairs =
            NEW_LINE.Split(Inputs.Day04).Where(it => !NEW_LINE.IsMatch(it))
            .Select(line =>
            {
                var assignments = line.Split(',');
                return (ParseAssignment(assignments[0]), ParseAssignment(assignments[1]));
            });

        public string SolvePart1() =>
            pairs.Where(pair => pair switch
            {
                var (e_1, e_2) when e_1.First() >= e_2.First() && e_1.Last() <= e_2.Last() => true,
                var (e_1, e_2) when e_2.First() >= e_1.First() && e_2.Last() <= e_1.Last() => true,
                _ => false
            })
            .Count()
            .ToString();

        public string SolvePart2() =>
            pairs.Where(pair => pair.Item1.Intersect(pair.Item2).Any()).Count().ToString();
    }
}
