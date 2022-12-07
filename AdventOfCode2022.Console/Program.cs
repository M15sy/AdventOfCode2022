using AdventOfCode2022.Core;

var solutions = new SolutionManager();

foreach (var day in solutions.AllSolutions)
{
    Console.WriteLine(day.PuzzleName);
    Console.WriteLine(@$"Part 1: {day.SolvePart1()}");
    Console.WriteLine(@$"Part 2: {day.SolvePart2()}");
    Console.WriteLine();
}
