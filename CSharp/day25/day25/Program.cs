using System;
using System.Collections.Generic;
using Tools;

namespace day25
{
    class Program
    {
        static void Main(string[] args)
        {
            var instructionSet = new List<Instruction>();
            foreach (var instruction in LineByLine.GetLines("input.txt"))
            {
                instructionSet.Add(Instruction.Create(instruction));
            }

            var computer = new Computer(instructionSet.ToArray());

            int registerValue;
            var validValue = -1;
            for (registerValue = 0; registerValue < int.MaxValue; registerValue++)
            {
                try
                {
                    computer.Reset();
                    computer.Registers[0] = registerValue;
                    computer.Run();
                    validValue = registerValue;
                    break;
                }
                catch 
                {
                   // Console.WriteLine($"Not {registerValue}");
                }
            }

            Console.WriteLine(validValue);
            Console.ReadKey();

        }
    }
}
