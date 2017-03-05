using System;
using System.IO;

namespace day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var screen = new LittleScreen();
            var file = new StreamReader("input.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var instruction = Instruction.Create(line);
                instruction.Execute(screen);
            }

            Console.WriteLine(screen.GetNumberOfLitPixels());
            Console.WriteLine(screen.ToString());
            Console.ReadKey();
        }
    }
}
