using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/8</c>.
    /// </summary>
    public sealed class Day08 : SolutionBase
    {
        /// <inheritdoc/>
        public override string PuzzleName => "--- Day 8: Treetop Tree House ---";

        /// <inheritdoc/>
        protected override string InputFileName => "Day08";

        /// <inheritdoc/>
        public override string SolvePart1() =>
            this.Solve(
                (noOfCols, noOfRows) => (noOfCols * 2) + (2 * (noOfRows - 2)),
                (prevCounter, col, row, colIndex, rowIndex) =>
                    !(IsHidden(col, rowIndex) && IsHidden(row, colIndex)) ?
                        prevCounter + 1 :
                        prevCounter);

        /// <inheritdoc/>
        public override string SolvePart2() =>
            this.Solve(
                (_, _) => 0,
                (prevCounter, col, row, colIndex, rowIndex) =>
                {
                    var height = row[colIndex];
                    var up = CalcViewingDistance(col.Take(rowIndex).Reverse().ToArray(), height);
                    var down = CalcViewingDistance(col.Skip(rowIndex + 1).ToArray(), height);
                    var left = CalcViewingDistance(row.Take(colIndex).Reverse().ToArray(), height);
                    var right = CalcViewingDistance(row.Skip(colIndex + 1).ToArray(), height);

                    var score = up * down * left * right;

                    return score > prevCounter ? score : prevCounter;
                });

        private static int[] GetColumn(int[,] matrix, int colIndex) =>
            Enumerable.Range(0, matrix.GetLength(0))
            .Select(x => matrix[x, colIndex])
            .ToArray();

        private static int[] GetRow(int[,] matrix, int rowIndex) =>
            Enumerable.Range(0, matrix.GetLength(1))
            .Select(x => matrix[rowIndex, x])
            .ToArray();

        private static bool IsHidden(int[] vector, int index)
        {
            var value = vector[index];
            return vector.Take(index).Any(it => it >= value) && vector.Skip(index + 1).Any(it => it >= value);
        }

        private static int CalcViewingDistance(int[] vector, int height)
        {
            int distance = 0;
            for (var i = 0; i < vector.Length; i++)
            {
                distance++;
                if (vector[i] >= height)
                {
                    break;
                }
            }

            return distance;
        }

        private string Solve(Func<int, int, int> initCounter, Func<int, int[], int[], int, int, int> nextCounter)
        {
            var trees = this.ReadTrees();
            var noOfCols = trees.GetLength(0);
            var noOfRows = trees.GetLength(1);
            int counter = initCounter(noOfCols, noOfRows);

            for (var colIndex = 1; colIndex < noOfCols - 1; colIndex++)
            {
                var col = GetColumn(trees, colIndex);
                for (var rowIndex = 1; rowIndex < noOfRows - 1; rowIndex++)
                {
                    var row = GetRow(trees, rowIndex);
                    counter = nextCounter(counter, col, row, colIndex, rowIndex);
                }
            }

            return counter.ToString();
        }

        private int[,] ReadTrees()
        {
            var lines = NewLine.Split(this.ReadInput()).Where(it => !NewLine.IsMatch(it)).ToArray();
            var noOfRows = lines.Count();
            var noOfCols = lines.First().Count();
            var trees = new int[noOfRows, noOfCols];

            for (var rowIndex = 0; rowIndex < noOfRows; rowIndex++)
            {
                var line = lines[rowIndex];
                for (var colIndex = 0; colIndex < noOfCols; colIndex++)
                {
                    trees[rowIndex, colIndex] = int.Parse(line[colIndex].ToString());
                }
            }

            return trees;
        }
    }
}
