using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace day20
{
    class Program
    {
        static void Main(string[] args)
        {
            var ranges = new List<Range>();
            foreach (var line in LineByLine.GetLines("input.txt"))
            {
                var split = line.Trim().Split('-');
                ranges.Add(new Range(uint.Parse(split[0]), uint.Parse(split[1])));
            }
            ranges = ranges.OrderBy(r => r.Low).ToList();
            var count = 0;
            do
            { 
                count = ranges.Count;
                for (var i = 0; i < ranges.Count - 1; i++)
                {
                    if (ranges[i].CanCombine(ranges[i + 1]))
                    {
                        ranges[i] = ranges[i].CombineWith(ranges[i + 1]);
                        ranges.RemoveAt(i + 1);
                    }
                }
            } while (count != ranges.Count);

            Console.WriteLine((ranges[0].Low > 0) ? 0 : ranges[0].High + 1);

            uint totalValid = 0;
            for (var i = 0; i < ranges.Count - 1; i++)
            {
                totalValid += ranges[i + 1].Low - ranges[i].High - 1;
            }

            Console.WriteLine(totalValid);
            Console.ReadKey();
        }
    }

    class Range
    {
        public uint Low { get; set; }
        public uint High { get; set; }

        public Range(uint low, uint high)
        {
            Low = low;
            High = high;
        }

        public bool CanCombine(Range range)
        {
            if (High + 1 == range.Low)
            {
                return true;
            }

            if (range.Low > Low && range.Low < High)
            {
                return true;
            }

            if (range.High > Low && range.High < High)
            {
                return true;
            }


            return false;
        }

        public Range CombineWith(Range range)
        {
            return new Range(
                Math.Min(Low, range.Low), 
                Math.Max(High, range.High));
        }
    }
}