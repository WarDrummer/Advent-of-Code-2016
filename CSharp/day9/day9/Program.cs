using System;
using Tools;

namespace day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;
            foreach (var line in LineByLine.GetLines("input.txt"))
            {
                count += new Decompressor().GetDecompressedLength(line);
            }
            Console.WriteLine(count);

            ulong modifiedCount = 0;
            foreach (var line in LineByLine.GetLines("input.txt"))
            {
                modifiedCount += new Decompressor().GetModifiedDecompressedLength(line);
            }
            Console.WriteLine(modifiedCount);
            Console.ReadKey();
        }
    }
}
