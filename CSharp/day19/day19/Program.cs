using System;

namespace day19
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfElves = 3004953;

            Console.WriteLine($"Part 1: {ElfRing.Part1(numberOfElves)}");
            Console.WriteLine($"Part 2: {ElfRing.Part2(numberOfElves)}");

            Console.ReadKey();
        }
    }
}
