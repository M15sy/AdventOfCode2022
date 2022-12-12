using System.Text.RegularExpressions;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// A class containing useful constants.
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        /// A regex to match line separators.
        /// </summary>
        internal static readonly Regex NewLine = new Regex("(\r\n|\r|\n)");

        /// <summary>
        /// A regex to match exactly two line separators.
        /// </summary>
        internal static readonly Regex DoubleNewLine = new Regex("((\r\n){2}|\r{2}|\n{2})");
    }
}
