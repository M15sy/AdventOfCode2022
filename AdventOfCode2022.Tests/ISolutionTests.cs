using AdventOfCode2022.Core;

namespace AdventOfCode2022.Tests;

public class ISolutionTests
{
    public static IEnumerable<object[]> TestCases => new List<object[]>
        {
            new object[] { new Day01(), "72478", "210367" },
            new object[] { new Day02(), "10595", "9541" },
            new object[] { new Day03(), "8349", "2681" },
            new object[] { new Day04(), "536", "845" },
            new object[] { new Day05(), "ZRLJGSCTR", "PRTTGRFPB" },
            new object[] { new Day06(), "1198", "3120" },
        };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void Should_Return_Expected(ISolution solution, string expected_1, string expected_2)
    {
        Assert.Equal(expected_1, solution.SolvePart1());
        Assert.Equal(expected_2, solution.SolvePart2());
    }
}
