using System.Text.RegularExpressions;

namespace AdventOfCode2022.Core
{
    static class Constants
    {
        internal static readonly Regex NEW_LINE = new Regex("(\r\n|\r|\n)");
        internal static readonly Regex DOUBLE_NEW_LINE = new Regex("(\r\n|\r|\n){2}");
    }
}
