using System;

namespace day14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                new KeyGenerator().GetIndexOfHashProducing64ThKey("abc") +
                " produces 64th key (expected 22728)");

            // 15189 is too high
            Console.WriteLine(
                new KeyGenerator().GetIndexOfHashProducing64ThKey("qzyelonm") + 
                " produces 64th key");
            Console.ReadKey();
        }
    }
}
