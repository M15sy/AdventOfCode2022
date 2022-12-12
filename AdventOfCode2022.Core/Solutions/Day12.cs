using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/12</c>.
    /// </summary>
    public sealed class Day12 : SolutionBase
    {
        private const string Heights = "abcdefghijklmnopqrstuvwxyz";
        private const string Start = "S";
        private const string End = "E";
        private const string NotFound = "No path found.";

        /// <inheritdoc/>
        public override string PuzzleName => "--- Day 12: Hill Climbing Algorithm ---";

        /// <inheritdoc/>
        protected override string InputFileName => "Day12";

        /// <inheritdoc/>
        public override string SolvePart1()
        {
            var heightmap = this.ReadHeightmap();
            var elevationsGrid = ToElevationGrid(heightmap);

            var startPos = FindAllInGrid(heightmap, Start).First();
            var endPos = FindAllInGrid(heightmap, End).First();

            var stepsGrid = new int?[elevationsGrid.GetLength(0), elevationsGrid.GetLength(1)];
            stepsGrid[startPos.Item1, startPos.Item2] = 0;

            Navigate(elevationsGrid, stepsGrid, endPos, startPos);

            return stepsGrid[endPos.Item1, endPos.Item2]?.ToString() ?? NotFound;
        }

        /// <inheritdoc/>
        public override string SolvePart2()
        {
            var heightmap = this.ReadHeightmap();
            var elevationsGrid = ToElevationGrid(heightmap);

            var startingPositions = FindAllInGrid(elevationsGrid, 0);
            var endPos = FindAllInGrid(heightmap, End).First();

            int? lowestSteps = null;

            foreach (var startPos in startingPositions)
            {
                var stepsGrid = new int?[elevationsGrid.GetLength(0), elevationsGrid.GetLength(1)];
                stepsGrid[startPos.Item1, startPos.Item2] = 0;

                Navigate(elevationsGrid, stepsGrid, endPos, startPos);

                if (lowestSteps is null || stepsGrid[endPos.Item1, endPos.Item2] < lowestSteps)
                {
                    lowestSteps = stepsGrid[endPos.Item1, endPos.Item2];
                }
            }

            return lowestSteps?.ToString() ?? NotFound;
        }

        private static void Navigate(int[,] elevationsGrid, int?[,] stepsGrid, (int, int) endPos, (int, int) curPos)
        {
            var (x, y) = curPos;
            var stepCount = stepsGrid[x, y] + 1;
            var newPositions = new (int, int)[] { (x, y - 1), (x, y + 1), (x - 1, y), (x + 1, y) };

            foreach (var newPosition in newPositions)
            {
                var (i, j) = newPosition;

                if (i >= 0 && i < stepsGrid.GetLength(0) && j >= 0 && j < stepsGrid.GetLength(1) && elevationsGrid[i, j] - elevationsGrid[x, y] <= 1)
                {
                    if (stepsGrid[i, j] is null || stepsGrid[i, j] > stepCount)
                    {
                        stepsGrid[i, j] = stepCount;
                        if (newPosition != endPos)
                        {
                            Navigate(elevationsGrid, stepsGrid, endPos, newPosition);
                        }
                    }
                }
            }
        }

        private static IList<(int, int)> FindAllInGrid<T>(T[,] grid, T thingToFind)
            where T : IEquatable<T>
        {
            var found = new List<(int, int)>();

            for (var i = 0; i < grid.GetLength(0); i++)
            {
                for (var j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j].Equals(thingToFind))
                    {
                        found.Add((i, j));
                    }
                }
            }

            return found;
        }

        private static int[,] ToElevationGrid(string[,] heightmap)
        {
            int maxX = heightmap.GetLength(0);
            int maxY = heightmap.GetLength(1);
            var elevationGrid = new int[maxX, maxY];

            for (var i = 0; i < maxX; i++)
            {
                for (var j = 0; j < maxY; j++)
                {
                    var height = heightmap[i, j];
                    elevationGrid[i, j] = height switch
                    {
                        Start => 0,
                        End => 25,
                        _ => Heights.IndexOf(height),
                    };
                }
            }

            return elevationGrid;
        }

        private string[,] ReadHeightmap()
        {
            var lines = NewLine.Split(this.ReadInput()).Where(it => !NewLine.IsMatch(it)).ToArray();
            int maxX = lines.First().Length;
            int maxY = lines.Length;
            var heightmap = new string[maxX, maxY];

            for (var j = 0; j < maxY; j++)
            {
                var row = lines[j];
                for (var i = 0; i < maxX; i++)
                {
                    heightmap[i, j] = row[i].ToString();
                }
            }

            return heightmap;
        }
    }
}
