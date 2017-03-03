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
            var tlsCount = 0;
            var sslCount = 0;
            while ((line = file.ReadLine()) != null)
            {
                var ip = new IPv7(line);

                if (ip.SupportsTls())
                    tlsCount++;

                if (ip.SupportsSsl())
                    sslCount++;
            }
             
            Console.WriteLine($"TLS: {tlsCount} SSL: {sslCount}");
            Console.ReadKey();
        }
    }
}
