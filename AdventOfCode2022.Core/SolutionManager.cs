namespace AdventOfCode2022.Core
{
    /// <summary>
    /// A class that creates instances of all solutions.
    /// </summary>
    public class SolutionManager
    {
        /// <summary>
        /// All the solutions.
        /// </summary>
        /// <returns>An IEnumerable of all the solutions.</returns>
        public IEnumerable<ISolution> AllSolutions()
        {
            yield return new Day01();
            yield return new Day02();
            yield return new Day03();
            yield return new Day04();
            yield return new Day05();
            yield return new Day06();
            yield return new Day07();
            yield return new Day08();
            yield return new Day09();
            yield return new Day10();
            yield return new Day11();
            yield return new Day12();
        }
    }
}
