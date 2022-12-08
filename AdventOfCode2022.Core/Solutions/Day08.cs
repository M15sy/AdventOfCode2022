using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/8</c>.
    /// </summary>
    public sealed class Day08 : SolutionBase
    {
        private readonly string[] lines;
        private readonly int noOfRows;
        private readonly int rowMid;
        private readonly int noOfCols;
        private readonly int colMid;
        private readonly int[,] trees;

        /// <summary>
        /// Initializes a new instance of the <see cref="Day08"/> class.
        /// </summary>
        public Day08()
        {
            this.lines = NewLine.Split(this.ReadInput()).Where(it => !NewLine.IsMatch(it)).ToArray();
            this.noOfRows = this.lines.Count();
            this.rowMid = this.noOfRows / 2;
            this.noOfCols = this.lines.First().Count();
            this.colMid = this.noOfCols / 2;
            this.trees = new int[this.noOfRows, this.noOfCols];

            for (var rowIndex = 0; rowIndex < this.noOfRows; rowIndex++)
            {
                var line = this.lines[rowIndex];
                for (var colIndex = 0; colIndex < this.noOfCols; colIndex++)
                {
                    this.trees[rowIndex, colIndex] = int.Parse(line[colIndex].ToString());
                }
            }
        }

        /// <inheritdoc/>
        public override string PuzzleName => "--- Day 8: Treetop Tree House ---";

        /// <inheritdoc/>
        protected override string InputFileName => "Day08";

        /// <inheritdoc/>
        public override string SolvePart1()
        {
            int visible = (this.noOfCols * 2) + (2 * (this.noOfRows - 2));
            for (var colIndex = 1; colIndex < this.noOfCols - 1; colIndex++)
            {
                var col = this.GetColumn(this.trees, colIndex);
                for (var rowIndex = 1; rowIndex < this.noOfRows - 1; rowIndex++)
                {
                    if (!(this.IsHidden(col, rowIndex, this.rowMid) &&
                        this.IsHidden(this.GetRow(this.trees, rowIndex), colIndex, this.colMid)))
                    {
                        visible++;
                    }
                }
            }

            return visible.ToString();
        }

        /// <inheritdoc/>
        public override string SolvePart2()
        {
            int max = 0;
            for (var colIndex = 1; colIndex < this.noOfCols - 1; colIndex++)
            {
                var col = this.GetColumn(this.trees, colIndex);
                for (var rowIndex = 1; rowIndex < this.noOfRows - 1; rowIndex++)
                {
                    var row = this.GetRow(this.trees, rowIndex);
                    var height = row[colIndex];

                    var up = this.CalcViewingDistance(col.Take(rowIndex).Reverse().ToArray(), height);
                    var down = this.CalcViewingDistance(col.Skip(rowIndex + 1).ToArray(), height);
                    var left = this.CalcViewingDistance(row.Take(colIndex).Reverse().ToArray(), height);
                    var right = this.CalcViewingDistance(row.Skip(colIndex + 1).ToArray(), height);

                    var score = up * down * left * right;
                    if (score > max)
                    {
                        max = score;
                    }
                }
            }

            return max.ToString();
        }

        private int[] GetColumn(int[,] matrix, int colIndex)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, colIndex])
                    .ToArray();
        }

        private int[] GetRow(int[,] matrix, int rowIndex)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowIndex, x])
                    .ToArray();
        }

        private bool IsHidden(int[] vector, int index, int mid)
        {
            var value = vector[index];
            return vector.Take(index).Any(it => it >= value) && vector.Skip(index + 1).Any(it => it >= value);
        }

        private int CalcViewingDistance(int[] vector, int height)
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
    }
}
