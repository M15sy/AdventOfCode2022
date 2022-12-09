using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/9</c>.
    /// </summary>
    public sealed class Day09 : SolutionBase
    {
        private readonly string up = "U";

        private readonly string right = "R";

        private readonly string down = "D";

        private readonly string left = "L";

        /// <inheritdoc/>
        public override string PuzzleName => "--- Day 9: Rope Bridge ---";

        /// <inheritdoc/>
        protected override string InputFileName => "Day09";

        /// <inheritdoc/>
        public override string SolvePart1() => this.Solve(2);

        /// <inheritdoc/>
        public override string SolvePart2() => this.Solve(10);

        private string Solve(int lengthOfRope)
        {
            var lines = NewLine.Split(this.ReadInput())
                               .Where(it => !NewLine.IsMatch(it))
                               .Select(it => it.Split(' '));
            var rope = Enumerable.Range(1, lengthOfRope).Select(_ => (0, 0)).ToArray();
            var tailPositions = new HashSet<(int, int)>();

            foreach (var line in lines)
            {
                var direction = line[0];
                var magnitude = int.Parse(line[1]);

                for (var i = 0; i < magnitude; i++)
                {
                    for (var j = 0; j < rope.Length; j++)
                    {
                        rope[j] = j switch
                        {
                            0 => this.Move(rope[j], direction),
                            _ => this.Follow(rope[j], rope[j - 1])
                        };
                        if (j == rope.Length - 1)
                        {
                            tailPositions.Add(rope[j]);
                        }
                    }
                }
            }

            return tailPositions.Count.ToString();
        }

        private (int, int) Move((int, int) position, string? direction) =>
            direction switch
            {
                "U" => (position.Item1, position.Item2 + 1),
                "R" => (position.Item1 + 1, position.Item2),
                "D" => (position.Item1, position.Item2 - 1),
                "L" => (position.Item1 - 1, position.Item2),
                _ => position
            };

        private (int, int) Follow((int, int) position, (int, int) positionOfThingToFollow)
        {
            var deltaX = positionOfThingToFollow.Item1 - position.Item1;
            var deltaY = positionOfThingToFollow.Item2 - position.Item2;

            if (Math.Abs(deltaX) < 2 && Math.Abs(deltaY) < 2)
            {
                return position;
            }

            var directionX = deltaX switch
            {
                > 0 => this.right,
                < 0 => this.left,
                _ => null,
            };
            var directionY = deltaY switch
            {
                > 0 => this.up,
                < 0 => this.down,
                _ => null,
            };

            return this.Move(this.Move(position, directionX), directionY);
        }
    }
}
