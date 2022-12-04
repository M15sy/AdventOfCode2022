using System.Diagnostics;
using AdventOfCode2022.Core;
using static System.FormattableString;

var solutions = new SolutionManager();

var stopwatch = new Stopwatch();

foreach (var day in solutions.AllSolutions)
{
    Console.WriteLine(day.PuzzleName);

    Console.WriteLine("-- Part 1 --");
    stopwatch.Start();
    Console.WriteLine(Invariant($"Answer: {day.SolvePart1()}"));
    stopwatch.Stop();
    Console.WriteLine(Invariant($"Time taken: {stopwatch.ElapsedMilliseconds} ms"));
    stopwatch.Reset();

    Console.WriteLine("-- Part 2 --");
    stopwatch.Start();
    Console.WriteLine(Invariant($"Answer: {day.SolvePart2()}"));
    stopwatch.Stop();
    Console.WriteLine(Invariant($"Time taken: {stopwatch.ElapsedMilliseconds} ms"));
    stopwatch.Reset();

    Console.WriteLine();
}
