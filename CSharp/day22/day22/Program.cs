using System;
using Tools;

namespace day22
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = new GridNode[39][]; // 39 x 25
            for (var i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new GridNode[25];
            }

            foreach (var line in LineByLine.GetLines("input.txt"))
            {
                if (line.StartsWith("/dev"))
                {
                    var node = GridNode.Create(line);
                    nodes[node.X][node.Y] = node;
                }
            }

            Part1(nodes);
            Console.ReadKey();
        }

        private static void Part1(GridNode[][] nodes)
        {
            var viablePairCount = 0;
            var xLength = nodes.Length;
            var yLength = nodes[0].Length;

            for (var x1 = 0; x1 < xLength; x1++)
            {
                for (var y1 = 0; y1 < yLength; y1++)
                {
                    for (var x2 = 0; x2 < xLength; x2++)
                    {
                        for (var y2 = 0; y2 < yLength; y2++)
                        {
                            if (nodes[x1][y1].MakesViablePair(nodes[x2][y2]))
                                viablePairCount++;
                        }
                    }
                }
            }

            Console.WriteLine(viablePairCount);
        }
    }
}
