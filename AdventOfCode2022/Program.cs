using System.Diagnostics;
using AdventOfCode2022.Core;
using static System.FormattableString;

var _solutions = new SolutionManager();
var stopwatch = new Stopwatch();

foreach (var solution in _solutions.AllSolutions)
{
    Console.WriteLine(solution.QuestionName);

    Console.WriteLine("-- Part 1 --");
    stopwatch.Start();
    Console.WriteLine(Invariant($"Answer: {solution.SolvePart1()}"));
    stopwatch.Stop();
    Console.WriteLine(Invariant($"Time taken: {stopwatch.ElapsedMilliseconds} ms"));
    stopwatch.Reset();

    Console.WriteLine("-- Part 2 --");
    stopwatch.Start();
    Console.WriteLine(Invariant($"Answer: {solution.SolvePart2()}"));
    stopwatch.Stop();
    Console.WriteLine(Invariant($"Time taken: {stopwatch.ElapsedMilliseconds} ms"));
    stopwatch.Reset();

    Console.WriteLine();
}
