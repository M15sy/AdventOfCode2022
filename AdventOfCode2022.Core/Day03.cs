using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    public class Day03 : ISolution
    {
        public string QuestionName => "--- Day 3: Rucksack Reorganization ---";

        private static readonly string priority = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static readonly IEnumerable<string> lines = NEW_LINE.Split(Inputs.Day03).Where(it => !NEW_LINE.IsMatch(it));

        public string SolvePart1() =>
           lines
           .Select(line =>
           {
               var half = line.Length / 2;
               var compartment_1 = line.Substring(0, half);
               var compartment_2 = line.Substring(half, half);

               return priority.IndexOf(compartment_1.First(c => compartment_2.Contains(c)));
           })
           .Sum()
           .ToString();

        public string SolvePart2()
        {
            var result = 0;

            for (int i = 2; i < lines.Count(); i += 3)
            {
                var rucksack_1 = lines.ElementAt(i - 2);
                var rucksack_2 = lines.ElementAt(i - 1);
                var rucksack_3 = lines.ElementAt(i);

                result += priority.IndexOf(rucksack_1.First(c => rucksack_2.Contains(c) && rucksack_3.Contains(c)));
            }

            return result.ToString();
        }
    }
}
