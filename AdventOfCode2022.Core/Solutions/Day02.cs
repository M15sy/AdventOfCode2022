using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/2</c>.
    /// </summary>
    public sealed class Day02 : SolutionBase
    {
        private enum Shape
        {
            Rock,
            Paper,
            Scissors,
        }

        /// <inheritdoc/>
        public override string PuzzleName => "--- Day 2: Rock Paper Scissors ---";

        /// <inheritdoc/>
        protected override string InputFileName => "Day02";

        /// <inheritdoc/>
        public override string SolvePart1() => this.Solve((input, _) => input switch
        {
            "X" => Shape.Rock,
            "Y" => Shape.Paper,
            "Z" => Shape.Scissors,
            _ => throw new ArgumentException($"Unknown input: {input}")
        });

        /// <inheritdoc/>
        public override string SolvePart2() => this.Solve((input, opponentShape) => input switch
        {
            "Z" => ToWin(opponentShape),
            "Y" => opponentShape,
            "X" => ToLoss(opponentShape),
            _ => throw new ArgumentException($"Unknown input: {input}")
        });

        private static Shape ParseOpponentShape(string input) => input switch
        {
            "A" => Shape.Rock,
            "B" => Shape.Paper,
            "C" => Shape.Scissors,
            _ => throw new ArgumentException($"Unknown input: {input}")
        };

        private static Shape ToWin(Shape shape) => shape switch
        {
            Shape.Rock => Shape.Paper,
            Shape.Paper => Shape.Scissors,
            Shape.Scissors => Shape.Rock,
            _ => throw new ArgumentException($"Unknown: shape {shape}")
        };

        private static Shape ToLoss(Shape shape) => shape switch
        {
            Shape.Rock => Shape.Scissors,
            Shape.Paper => Shape.Rock,
            Shape.Scissors => Shape.Paper,
            _ => throw new ArgumentException($"Unknown shape: {shape}")
        };

        private static int CalcShapeScore(Shape shape) => shape switch
        {
            Shape.Rock => 1,
            Shape.Paper => 2,
            Shape.Scissors => 3,
            _ => throw new ArgumentException($"Unknown shape: {shape}")
        };

        private static int CalcOutcomeScore(Shape yourShape, Shape opponentShape) => yourShape switch
        {
            var shape when shape == ToWin(opponentShape) => 6,
            var shape when shape == opponentShape => 3,
            _ => 0
        };

        private string Solve(Func<string, Shape, Shape> parseMyShape) =>
            NewLine.Split(this.ReadInput()).Where(it => !NewLine.IsMatch(it))
            .Select((round) =>
            {
                var shapes = round.Split();
                var opponentShape = ParseOpponentShape(shapes[0]);
                var myShape = parseMyShape(shapes[1], opponentShape);
                return CalcShapeScore(myShape) + CalcOutcomeScore(myShape, opponentShape);
            })
            .Sum()
            .ToString();
    }
}
