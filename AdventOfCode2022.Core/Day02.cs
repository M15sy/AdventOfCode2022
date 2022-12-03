using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    public sealed class Day02 : ISolution
    {
        public string QuestionName => "--- Day 2: Rock Paper Scissors ---";

        private enum Shape { Rock, Paper, Scissors }

        private Shape ParseOpponentShape(string input) => input switch
        {
            "A" => Shape.Rock,
            "B" => Shape.Paper,
            "C" => Shape.Scissors,
            _ => throw new ArgumentException($"Unknown input: {input}")
        };

        private Shape ToWin(Shape shape) => shape switch
        {
            Shape.Rock => Shape.Paper,
            Shape.Paper => Shape.Scissors,
            Shape.Scissors => Shape.Rock,
            _ => throw new ArgumentException($"Unknown: shape {shape}")
        };

        private Shape ToLoss(Shape shape) => shape switch
        {
            Shape.Rock => Shape.Scissors,
            Shape.Paper => Shape.Rock,
            Shape.Scissors => Shape.Paper,
            _ => throw new ArgumentException($"Unknown shape: {shape}")
        };

        private int CalcShapeScore(Shape shape) => shape switch
        {
            Shape.Rock => 1,
            Shape.Paper => 2,
            Shape.Scissors => 3,
            _ => throw new ArgumentException($"Unknown shape: {shape}")
        };

        private int CalcOutcomeScore(Shape yourShape, Shape opponentShape) => yourShape switch
        {
            var shape when shape == ToWin(opponentShape) => 6,
            var shape when shape == opponentShape => 3,
            _ => 0
        };

        private string Solve(Func<string, Shape, Shape> ParseMyShape) =>
            NEW_LINE.Split(Inputs.Day02)
                .Where(it => !NEW_LINE.IsMatch(it))
                .Select((round) =>
                {
                    var shapes = round.Split();
                    var opponentShape = ParseOpponentShape(shapes[0]);
                    var myShape = ParseMyShape(shapes[1], opponentShape);
                    return CalcShapeScore(myShape) + CalcOutcomeScore(myShape, opponentShape);
                })
                .Sum()
                .ToString();

        public string SolvePart1() => Solve((input, _) => input switch
        {
            "X" => Shape.Rock,
            "Y" => Shape.Paper,
            "Z" => Shape.Scissors,
            _ => throw new ArgumentException($"Unknown input: {input}")
        });

        public string SolvePart2() => Solve((input, opponentShape) => input switch
        {
            "Z" => ToWin(opponentShape),
            "Y" => opponentShape,
            "X" => ToLoss(opponentShape),
            _ => throw new ArgumentException($"Unknown input: {input}")
        });
    }
}
