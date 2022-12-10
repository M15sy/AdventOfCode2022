using static AdventOfCode2022.Core.Constants;

namespace AdventOfCode2022.Core
{
    /// <summary>
    /// Class representation of a solution for <c>https://adventofcode.com/2022/day/7</c>.
    /// </summary>
    public sealed class Day07 : SolutionBase
    {
        /// <summary>
        /// Defines a filesystem node.
        /// </summary>
        private interface INode
        {
            /// <summary>
            /// Gets the name of the node.
            /// </summary>
            string Name { get; }

            /// <summary>
            /// Gets the size of the node.
            /// </summary>
            int Size { get; }
        }

        /// <inheritdoc/>
        public override string PuzzleName => "--- Day 7: No Space Left On Device ---";

        /// <inheritdoc/>
        protected override string InputFileName => "Day07";

        /// <inheritdoc/>
        public override string SolvePart1() =>
            this.GetDirSizesWhere(_ => it => it <= 100000).Sum().ToString();

        /// <inheritdoc/>
        public override string SolvePart2() =>
            this.GetDirSizesWhere(spaceUsed =>
            {
                var target = 30000000 - (70000000 - spaceUsed);
                return it => it >= target;
            })
            .Min()
            .ToString();

        private IEnumerable<int> GetDirSizesWhere(Func<int, Func<int, bool>> predicateFactory)
        {
            var lines = NewLine.Split(this.ReadInput()).Where(it => !NewLine.IsMatch(it));

            Dir? tree = null;
            Dir? currentDir = null;
            List<Dir> dirs = new List<Dir>();

            foreach (var line in lines)
            {
                if (line != "$ ls")
                {
                    var parts = line.Split(" ");
                    if (tree is null)
                    {
                        // root directory
                        tree = new Dir(parts[2]);
                        dirs.Add(tree);
                        currentDir = tree;
                    }
                    else if (currentDir is null)
                    {
                        // this shouldn't happen
                        throw new Exception("currentDir should not be null.");
                    }
                    else if (parts[0] == "$" && parts[1] == "cd")
                    {
                        // change directory
                        currentDir = parts[2] == ".." ? currentDir.Parent : currentDir.Children.First(it => it.Name == parts[2]) as Dir;
                    }
                    else if (parts[0] == "dir")
                    {
                        // add directory node
                        var dir = new Dir(parts[1]);
                        dir.Parent = currentDir;
                        dirs.Add(dir);
                        currentDir?.Children.Add(dir);
                    }
                    else
                    {
                        // add file node
                        currentDir?.Children.Add(new File(parts[1], int.Parse(parts[0])));
                    }
                }
            }

            var spaceUsed = tree?.Size ?? 0;

            return dirs.Select(it => it.Size).Where(predicateFactory(spaceUsed));
        }

        private class File : INode
        {
            internal File(string name, int size)
            {
                this.Name = name;
                this.Size = size;
            }

            public string Name { get; }

            public int Size { get; }
        }

        private class Dir : INode
        {
            internal Dir(string name)
            {
                this.Name = name;
            }

            public string Name { get; }

            public Dir? Parent { get; set; }

            public ICollection<INode> Children { get; } = new List<INode>();

            public int Size
            {
                get => this.Children.Select(it => it.Size).Sum();
            }
        }
    }
}
