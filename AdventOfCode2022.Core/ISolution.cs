namespace AdventOfCode2022.Core
{
    public interface ISolution
    {
        string QuestionName { get; }

        string SolvePart1();

        string SolvePart2();
    }
}
