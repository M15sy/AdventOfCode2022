using AdventOfCode2022.Core;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode2022.Benchmark
{
    /// <summary>
    /// Benchmarker for all the solutions.
    /// </summary>
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class SolutionsBenchmarker
    {
        private SolutionManager solutions = new SolutionManager();

        /// <summary>
        /// All the solutions.
        /// </summary>
        /// <returns>An IEnumerable of all the solutions.</returns>
        public IEnumerable<ISolution> Solutions() => this.solutions.AllSolutions();

        /// <summary>
        /// Solves part 1 of the solution.
        /// </summary>
        /// <param name="solution">The solution to solve.</param>
        [Benchmark]
        [ArgumentsSource(nameof(Solutions))]
        public void SolvePart1(ISolution solution)
        {
            solution.SolvePart1();
        }

        /// <summary>
        /// Solves part 2 of the solution.
        /// </summary>
        /// <param name="solution">The solution to solve.</param>
        [Benchmark]
        [ArgumentsSource(nameof(Solutions))]
        public void SolvePart2(ISolution solution)
        {
            solution.SolvePart2();
        }
    }
}
