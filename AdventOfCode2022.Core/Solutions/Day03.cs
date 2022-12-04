﻿using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/3</c>.
    /// </summary>
    public sealed class Day03 : ISolution
    {
        private static readonly IEnumerable<string> Lines = NewLine.Split(Inputs.Day03).Where(it => !NewLine.IsMatch(it));

        private static readonly string Priority = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <inheritdoc/>
        public string PuzzleName => "--- Day 3: Rucksack Reorganization ---";

        /// <inheritdoc/>
        public string SolvePart1() =>
           Lines
           .Select(line =>
           {
               var mid = line.Length / 2;
               return GetPriority(line[0..mid], line[mid..]);
           })
           .Sum()
           .ToString();

        /// <inheritdoc/>
        public string SolvePart2() =>
            Lines
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

        private static int GetPriority(string? first, params string?[] rest)
        {
            if (first is null)
            {
                throw new ArgumentException("Expect 'first' not to be null");
            }

            if (rest is null || rest.Any(it => it is null))
            {
                throw new ArgumentException("Expect 'rest' not to be null, empty or to contain null");
            }

            return Priority.IndexOf(first.First(c => rest.All(it => it is not null && it.Contains(c))));
        }
    }
}