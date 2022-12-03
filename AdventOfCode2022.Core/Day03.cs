using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    public sealed class Day03 : ISolution
    {
        public string QuestionName => "--- Day 3: Rucksack Reorganization ---";

        private static readonly IEnumerable<string> lines = NEW_LINE.Split(Inputs.Day03).Where(it => !NEW_LINE.IsMatch(it));

        private static readonly string priority = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static int GetPriority(string? first, params string?[]? rest)
        {
            if (first is null) throw new ArgumentException("Expect 'first' not to be null");
            if (rest is null || rest.Any(it => it is null))
            {
                throw new ArgumentException("Expect 'rest' not to be null, empty or to contain null");
            }
            return priority.IndexOf(first.First(c => rest.All(it => it is not null && it.Contains(c))));
        }

        public string SolvePart1() =>
           lines
           .Select(line =>
           {
               var mid = line.Length / 2;
               return GetPriority(line[0..mid], line[mid..]);
           })
           .Sum()
           .ToString();

        public string SolvePart2() =>
            lines
            .Aggregate(new List<List<string?>>(), (acc, cur) =>
            {
                bool popLast = acc.Count() > 0 && acc[acc.Count() - 1][2] == null;
                var group = popLast ? acc.Last() : new List<string?>() { null, null, null };
                group[group.IndexOf(null)] = cur;
                return acc.SkipLast(popLast ? 1 : 0).Append(group).ToList();
            })
            .Select(group => GetPriority(group[0], group[1], group[2]))
            .Sum()
            .ToString();
    }
}
