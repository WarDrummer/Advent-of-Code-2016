using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace day24
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = LineByLine.GetLines("input.txt").ToArray();
            var map = new Map(lines);
            map.Initialize();
            Console.WriteLine(map.ToString());
            Console.ReadKey();
        }    
    }
}
