using System.Numerics;
using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/11</c>.
    /// </summary>
    public sealed class Day11 : SolutionBase
    {
        /// <inheritdoc/>
        public override string PuzzleName => "--- Day 11: Monkey in the Middle ---";

        /// <inheritdoc/>
        protected override string InputFileName => "Day11";

        /// <inheritdoc/>
        public override string SolvePart1() => this.Solve(20, 3);

        /// <inheritdoc/>
        public override string SolvePart2() => this.Solve(10000);

        private string Solve(int noOfRounds, int reliefFactor = 1)
        {
            var medicationFrequency = 25;
            var monkeys = this.GetMonkeys();
            var monkeyInspections = new Dictionary<string, BigInteger>();
            var lowestCommonMultiple = monkeys.Select(it => it.ThingToTestAgainst).Aggregate(new BigInteger(1), (acc, cur) => acc * cur);

            for (var round = 0; round < noOfRounds; round++)
            {
                foreach (var monkey in monkeys)
                {
                    while (monkey.Items.Count > 0)
                    {
                        if (!monkeyInspections.TryAdd(monkey.Name, 1))
                        {
                            monkeyInspections[monkey.Name] = monkeyInspections[monkey.Name] + 1;
                        }

                        BigInteger item = monkey.Items.Dequeue();
                        BigInteger worry = monkey.Inspect(item) / reliefFactor;
                        monkeys[monkey.GetNextMonkeyIndex(worry)]?.Items.Enqueue(worry);
                    }
                }

                if (round % medicationFrequency == 0)
                {
                    monkeys.ForEach(m => m.TakeAChillPill(lowestCommonMultiple));
                }
            }

            return monkeyInspections.Select(it => it.Value).Order().TakeLast(2).Aggregate(new BigInteger(1), (acc, cur) => acc * cur).ToString();
        }

        private List<Monkey> GetMonkeys() =>
            DoubleNewLine.Split(this.ReadInput())
                  .Select(it => NewLine.Split(it).Where(it => !NewLine.IsMatch(it)).Select(it => it.Trim()).ToArray())
                  .Where(it => it.Length == 6)
                  .Select(input =>
                  {
                      var name = input[0].Replace(":", string.Empty);

                      var startingItems = input[1].Replace("Starting items: ", string.Empty).Split(", ").Select(it => BigInteger.Parse(it)).ToArray();

                      var operationParts = input[2].Split(' ').TakeLast(2);
                      Func<BigInteger, BigInteger> operation = (operationParts.First(), operationParts.Last()) switch
                      {
                          ("*", "old") => it => BigInteger.Pow(it, 2),
                          ("*", _) => it => it * BigInteger.Parse(operationParts.Last()),
                          ("/", "old") => it => new BigInteger(1),
                          ("/", _) => it => it / BigInteger.Parse(operationParts.Last()),
                          ("+", "old") => it => it + it,
                          ("+", _) => it => it + BigInteger.Parse(operationParts.Last()),
                          ("-", "old") => it => new BigInteger(0),
                          ("-", _) => it => it - BigInteger.Parse(operationParts.Last()),
                          (_, _) => throw new ArgumentException($@"Unknown operator")
                      };

                      var test = BigInteger.Parse(input[3].Split(' ').Last());
                      var monkeyTrue = int.Parse(input[4].Split(' ').Last());
                      var monkeyFalse = int.Parse(input[5].Split(' ').Last());

                      return new Monkey(name, startingItems, operation, test, monkeyTrue, monkeyFalse);
                  })
                  .ToList();

        private class Monkey
        {
            private readonly Func<BigInteger, BigInteger> operation;
            private readonly int trueMonkeyIndex;
            private readonly int falseMonkeyIndex;

            private Queue<BigInteger> items;

            public Monkey(string name, BigInteger[] startingItems, Func<BigInteger, BigInteger> operation, BigInteger thingToTestAgainst, int trueMonkeyIndex, int falseMonkeyIndex)
            {
                this.Name = name;
                this.items = new Queue<BigInteger>(startingItems);
                this.operation = operation;
                this.ThingToTestAgainst = thingToTestAgainst;
                this.trueMonkeyIndex = trueMonkeyIndex;
                this.falseMonkeyIndex = falseMonkeyIndex;
            }

            public string Name { get; }

            public Queue<BigInteger> Items { get => this.items; }

            public BigInteger ThingToTestAgainst { get; }

            public BigInteger Inspect(BigInteger item) => this.operation(item);

            public int GetNextMonkeyIndex(BigInteger item) =>
                item % this.ThingToTestAgainst == 0 ? this.trueMonkeyIndex : this.falseMonkeyIndex;

            public void TakeAChillPill(BigInteger milliGrams)
            {
                this.items = new Queue<BigInteger>(this.items.Select(it => it % milliGrams).ToArray());
            }
        }
    }
}
