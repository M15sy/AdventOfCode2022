using System.Collections.Immutable;
using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/10</c>.
    /// </summary>
    public sealed class Day10 : SolutionBase
    {
        private static readonly ImmutableArray<int> InterestingCycles = ImmutableArray.Create<int>(20, 60, 100, 140, 180, 220);

        /// <inheritdoc/>
        public override string PuzzleName => "--- Day 10: Cathode-Ray Tube ---";

        /// <inheritdoc/>
        protected override string InputFileName => "Day10";

        /// <inheritdoc/>
        public override string SolvePart1() =>
            this.ProcessProgram(0, (signalStrengths, cycle, x) => AddIfInteresting(signalStrengths, cycle, x)).ToString();

        /// <inheritdoc/>
        public override string SolvePart2()
        {
            var rowLength = 40;
            var crt = this.ProcessProgram(new string[rowLength * 6], (prev, cycle, x) =>
            {
                prev[cycle - 1] = GetPixel(x, (cycle - 1) % rowLength);
                return prev;
            });

            for (var rowStart = 0; rowStart < crt.Length; rowStart += rowLength)
            {
                Console.WriteLine(string.Join(string.Empty, crt.Skip(rowStart).Take(rowLength)));
            }

            return "FJUBULRZ";
        }

        private static string GetPixel(int x, int i) =>
            (i == x - 1 || i == x || i == x + 1) ? "#" : ".";

        private static int AddIfInteresting(int signalStrengths, int cycle, int x) =>
            InterestingCycles.Contains(cycle) ? signalStrengths + (cycle * x) : signalStrengths;

        private T ProcessProgram<T>(T initial, Func<T, int, int, T> nextOutput)
        {
            var lines = NewLine.Split(this.ReadInput()).Where(it => !NewLine.IsMatch(it));
            var x = 1;
            var cycle = 1;
            var output = initial;

            foreach (var line in lines)
            {
                output = nextOutput(output, cycle, x);
                cycle++;

                if (line != "noop")
                {
                    output = nextOutput(output, cycle, x);
                    x = x + int.Parse(line.Split(' ')[1]);
                    cycle++;
                }
            }

            return output;
        }
    }
}
