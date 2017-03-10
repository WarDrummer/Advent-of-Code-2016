using System;
using Tools;

namespace day10
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var line in LineByLine.GetLines("input.txt"))
            {
                MasterControlProgram.Execute(line);
            }
            
            Console.WriteLine(new ChipStorage().WhoCompared(61, 17));
            Console.WriteLine(new ChipStorage().GetBinValues(0, 1, 2));
            Console.ReadKey();
        }
    }
}
