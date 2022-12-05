using System;
using System.Text.RegularExpressions;
using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/5</c>.
    /// </summary>
    public sealed class Day05 : SolutionBase
    {
        /// <inheritdoc/>
        public override string PuzzleName => "--- Day 5: Supply Stacks ---";

        /// <inheritdoc/>
        protected override string InputFileName => "Day05";

        /// <inheritdoc/>
        public override string SolvePart1() => this.Solve((quantity, from, to) =>
        {
            for (var i = 0; i < quantity; i++)
            {
                to.Push(from.Pop());
            }
        });

        /// <inheritdoc/>
        public override string SolvePart2() => this.Solve((quantity, from, to) =>
        {
            var cratesToMove = new Stack<string>();

            for (var i = 0; i < quantity; i++)
            {
                cratesToMove.Push(from.Pop());
            }

            for (var i = 0; i < quantity; i++)
            {
                to.Push(cratesToMove.Pop());
            }
        });

        private string Solve(Action<int, Stack<string>, Stack<string>> mutate)
        {
            var input = DoubleNewLine.Split(this.ReadInput());
            List<Stack<string>> stacks = this.ReadInitialState(input.First());
            var moves = this.ReadMoves(input.Last());

            moves.ForEach(move =>
            {
                var quantity = int.Parse(move[1]);
                var from = stacks[int.Parse(move[3]) - 1];
                var to = stacks[int.Parse(move[5]) - 1];

                mutate(quantity, from, to);
            });

            return string.Join(string.Empty, stacks.Select(it => it.Peek()));
        }

        private List<Stack<string>> ReadInitialState(string input)
        {
            var lines = NewLine.Split(input).Where(it => !NewLine.IsMatch(it)).Reverse();
            var alpha = new Regex(@"\w{1}");
            List<Stack<string>>? stacks = null;

            foreach (var line in lines)
            {
                if (stacks is null)
                {
                    var noOfStacks = line.Replace(" ", string.Empty).Length;
                    stacks = Enumerable.Range(1, noOfStacks).Select(it => new Stack<string>()).ToList();
                }
                else
                {
                    for (var i = 0; i < stacks.Count(); i++)
                    {
                        var crate = line.Substring((i * 4) + 1, 1);
                        if (alpha.IsMatch(crate))
                        {
                            stacks[i].Push(crate);
                        }
                    }
                }
            }

            return stacks ?? new List<Stack<string>>();
        }

        private List<string[]> ReadMoves(string input) =>
            NewLine.Split(input).Where(it => !NewLine.IsMatch(it)).Select(m => m.Split(" ")).ToList();
    }
}
