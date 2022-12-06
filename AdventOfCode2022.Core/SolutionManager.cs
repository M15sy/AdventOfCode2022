namespace AdventOfCode2022.Core
{
    /// <summary>
    /// A class that creates instances of all solutions.
    /// </summary>
    public class SolutionManager
    {
        private readonly IList<ISolution> solutions = new List<ISolution>()
        {
            new Day01(),
            new Day02(),
            new Day03(),
            new Day04(),
            new Day05(),
            new Day06(),
        };

        /// <summary>
        /// Gets a list of all the solutions.
        /// </summary>
        public IList<ISolution> AllSolutions { get => this.solutions; }
    }
}
