using System;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// A base class representing a solution for an Advent of Code puzzle.
    /// </summary>
    public abstract class SolutionBase : ISolution
    {
        /// <inheritdoc/>
        public abstract string PuzzleName { get; }

        /// <summary>
        /// Gets the name of the input file.
        /// </summary>
        protected abstract string InputFileName { get; }

        /// <inheritdoc/>
        public abstract string SolvePart1();

        /// <inheritdoc/>
        public abstract string SolvePart2();

        /// <summary>
        /// Reads the puzzle input file.
        /// </summary>
        /// <returns>The puzzle input data line by line.</returns>
        protected string ReadInput() =>
            File.ReadAllText($@"{AppDomain.CurrentDomain.BaseDirectory}Inputs/{this.InputFileName}.txt");
    }
}
