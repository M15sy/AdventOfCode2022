using System.Collections;
using AdventOfCode2022.Core;

public class ISolutionTests
{
    [TestCaseSource(nameof(ISolutionTestCases))]
    public void Should_Return_Expected(ISolution solution, string expected_1, string expected_2)
    {
        solution.SolvePart1().Should().Be(expected_1);
        solution.SolvePart2().Should().Be(expected_2);
    }

    private static IEnumerable ISolutionTestCases()
    {
        yield return new TestCaseData(new Day01(), "72478", "210367").SetName("Day01_{m}");
        yield return new TestCaseData(new Day02(), "10595", "9541").SetName("Day02_{m}");
        yield return new TestCaseData(new Day03(), "8349", "2681").SetName("Day03_{m}");
        yield return new TestCaseData(new Day04(), "536", "845").SetName("Day04_{m}");
        yield return new TestCaseData(new Day05(), "ZRLJGSCTR", "PRTTGRFPB").SetName("Day05_{m}");
        yield return new TestCaseData(new Day06(), "1198", "3120").SetName("Day06_{m}");
        yield return new TestCaseData(new Day07(), "1770595", "2195372").SetName("Day07_{m}");
        yield return new TestCaseData(new Day08(), "1787", "440640").SetName("Day08_{m}");
    }
}
