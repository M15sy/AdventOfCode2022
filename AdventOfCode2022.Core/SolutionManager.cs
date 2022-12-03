namespace AdventOfCode2022.Core
{
    public class SolutionManager
    {
        private IList<ISolution> _solutions = new List<ISolution>(){
            new Day01(),
            new Day02()
        };

        public IList<ISolution> AllSolutions
        {
            get { return _solutions; }
        }
    }
}
