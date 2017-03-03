using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var fs = File.Open("input.txt", FileMode.Open))
            {
                var reader = new StreamReader(fs);
                string line;
                var fa = new FrequencyAnalyzer(8);
                while (null != (line = reader.ReadLine()))
                {
                    fa.Add(line);
                }
                Console.WriteLine(fa.GetMessage());
                Console.WriteLine(fa.GetModifiedMessage());
            }
            
            Console.ReadKey();
        }
    }
}
