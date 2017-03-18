using System;

namespace day14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                new KeyGenerator().GetIndexOfHashProducing64ThKey("abc") + 
                " produces 64th key (22728 expected)");
            Console.ReadKey();
        }
    }
}
