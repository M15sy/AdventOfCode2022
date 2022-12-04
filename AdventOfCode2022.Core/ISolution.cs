namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Defines a solution.
    /// </summary>
    public interface ISolution
    {
        /// <summary>
        /// Gets the name of the puzzle.
        /// </summary>
        string PuzzleName { get; }

        /// <summary>
        /// Solve part 1 of the puzzle.
        /// </summary>
        /// <returns>The answer as a <see cref="string"/>.</returns>
        string SolvePart1();

        /// <summary>
        /// Solve part 2 of the puzzle.
        /// </summary>
        /// <returns>The answer as a <see cref="string"/>.</returns>
        string SolvePart2();
    }
}
