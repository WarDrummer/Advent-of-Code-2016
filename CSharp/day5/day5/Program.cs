using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var key = PartOne(md5Hash);
                Console.WriteLine(new string(key));

                key = PartTwo(md5Hash);
                Console.WriteLine(new string(key));

                Console.ReadKey();
            }
        }

        private static char[] PartOne(MD5 md5Hash)
        {
            var key = new char[8];
            var keyIndex = 0;
            var seedPostfix = 0;
            var seedPrefix = "ugkcyxxp";
            while (keyIndex < 8)
            {
                var seed = seedPrefix + seedPostfix++;
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(seed));
                var firstPart = data[0].ToString("x2");
                var secondPart = data[1].ToString("x2");
                var thirdPart = data[2].ToString("x2");
                if (firstPart[0] == '0' && firstPart[1] == '0' &&
                    secondPart[0] == '0' && secondPart[1] == '0' &&
                    thirdPart[0] == '0')
                {
                    key[keyIndex++] = thirdPart[1];
                    Console.WriteLine(new string(key));
                }
            }
            return key;
        }

        private static char[] PartTwo(MD5 md5Hash)
        {
            var key = new char[8];
            var keyIndex = 0;
            var seedPostfix = 0;
            var seedPrefix = "ugkcyxxp";
            var indicesToFill = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7' };
            while (indicesToFill.Count > 0)
            {
                var seed = seedPrefix + seedPostfix++;
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(seed));
                var firstPart = data[0].ToString("x2");
                var secondPart = data[1].ToString("x2");
                var thirdPart = data[2].ToString("x2");
                if (firstPart[0] == '0' && firstPart[1] == '0' &&
                    secondPart[0] == '0' && secondPart[1] == '0' &&
                    thirdPart[0] == '0')
                {
                    if (indicesToFill.Contains(thirdPart[1]))
                    {
                        indicesToFill.Remove(thirdPart[1]);
                        var fourthPart = data[3].ToString("x2");
                        key[thirdPart[1] - '0'] = fourthPart[0];
                        Console.WriteLine(new string(key));
                    }
                }
            }
            return key;
        }
    }
}
