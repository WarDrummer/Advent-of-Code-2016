using System;

namespace day14
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(
            //    new KeyGenerator().IndexOf64thKey("abc") +
            //    " produces 64th key (expected 22551)");

            Console.WriteLine(
                new KeyGenerator().IndexOf64thKey("qzyelonm") + 
                " produces 64th key");

            Console.ReadKey();
        }
    }
}
