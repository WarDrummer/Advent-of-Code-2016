using System;
using System.Collections.Generic;
using System.IO;

namespace day12.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new StreamReader("input.txt");
            string line;
            var instructions = new List<Instruction>();
            while ((line = file.ReadLine()) != null)
            {
                instructions.Add(Instruction.Create(line));
            }

            var computer = new Computer(instructions.ToArray());
            computer.Run();
            Console.WriteLine(computer.ToString());
            Console.ReadKey();
        }
    }
}
