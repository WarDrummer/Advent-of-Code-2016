using System;
using System.IO;

namespace day7
{
    class Program
    {
        static void Main(string[] args)
        {

            var file = new StreamReader("input.txt");
            string line;
            var count = 0;
            while ((line = file.ReadLine()) != null)
            {
                var ip = new IPv7(line);
                if (ip.SupportsTls())
                    count++;
            }
             
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
