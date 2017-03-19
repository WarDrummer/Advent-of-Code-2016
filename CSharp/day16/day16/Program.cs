using System;
using System.Text;

namespace day16
{
    class Program
    {
        static void Main(string[] args)
        {
            //var d = new Data("10000", 20);
            //d.Expand();
            //Console.WriteLine(d);
            //Console.WriteLine("10000011110010000111");

            //var checksum = d.ToString();
            //while ((checksum = Data.GetChecksum(checksum)).Length % 2 == 0);
            //Console.WriteLine(checksum);

            // Part 1
            var d = new Data("10001110011110000", 272);
            d.Expand();

            var checksum = d.ToString();
            while ((checksum = Data.GetChecksum(checksum)).Length % 2 == 0) ;
            Console.WriteLine(checksum);

            // Part 2
            var d2 = new Data("10001110011110000", 35651584);
            d2.Expand();

            checksum = d2.ToString();
            while ((checksum = Data.GetChecksum(checksum)).Length % 2 == 0) ;
            Console.WriteLine(checksum);

            Console.ReadKey();
        }
    }

    class Data
    {
        private readonly bool[] _data;
        private int _currentIndex;

        public Data(string initial, int length)
        {
            _data = new bool[length];
            _currentIndex = initial.Length;
            for (var i = 0; i < _currentIndex; i++)
                _data[i] = initial[i] == '1';
        }

        public void Expand()
        {
            while (_currentIndex < _data.Length)
            {
                _data[_currentIndex] = false;
                var newCurrentIndex = _currentIndex + 1;
                for (var i = _currentIndex - 1; i >= 0 && newCurrentIndex < _data.Length; i--, newCurrentIndex++)
                {
                    _data[newCurrentIndex] = !_data[i];
                }
                _currentIndex = newCurrentIndex;
            }
        }

        public static string GetChecksum(string data)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < data.Length; i += 2)
            {
                sb.Append(data[i] == data[i + 1] ? '1':'0');
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var value in _data)
            {
                sb.Append(value ? '1' : '0');
            }
            return sb.ToString();
        }
    }
}
