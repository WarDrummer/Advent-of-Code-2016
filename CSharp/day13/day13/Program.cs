using System;

namespace day13
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = new Coordinate(1, 1);
            var goal = new Coordinate(31, 39);
            var unreachableGoal = new Coordinate(-1, -1);

            // part 1
            Console.WriteLine(new ShortestPathFinder(start, goal).GetFewestNumberOfSteps(1364));

            // part 2
            Console.WriteLine(new ShortestPathFinder(start, unreachableGoal).GetFewestNumberOfSteps(1364, 50));

            Console.ReadKey();
        }
    }
}
