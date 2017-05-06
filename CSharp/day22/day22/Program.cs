using System;
using System.Text;
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

            Part2(nodes); // print for manual interpretation
            // 64 steps to move empty space around large capacity nodes and to top-right cell
            // 5 steps to use empty cell to move target data
            // 37 step to goal 
            // 64 + (5 * 37) = 249

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

        private static void Part2(GridNode[][] nodes)
        {
            var xLength = nodes.Length;
            var yLength = nodes[0].Length;
            var sb = new StringBuilder();
            for (var y = 0; y < yLength; y++)
            {
                for (var x = 0; x < xLength; x++)
                {
                    var node = nodes[x][y];
                    sb.Append($"{node.Used:D3}/{(node.Available + node.Used):D3} ");
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb);
        }
    }
}
