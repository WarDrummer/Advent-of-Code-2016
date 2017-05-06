using System;
using System.Linq;
using Tools;

namespace day24
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = LineByLine.GetLines("input-part1.txt").ToArray();
            var map = new Map(lines);
            map.Initialize();
            Console.WriteLine(map.GetMinimumMovesToVisitAllNodes());
            Console.WriteLine(map.GetMinimumMovesToVisitAllNodesAndReturn());
            Console.ReadKey();
        }    
    }
}
