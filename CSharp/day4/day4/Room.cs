using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day4
{
    public class Room
    {
        private readonly string _input;

        public int SectorID
        {
            get
            {
                var indexOfSector = _input.IndexOf('[') - 3;
                return int.Parse(_input.Substring(indexOfSector, 3));
            }
        }

        public string EncodedName => _input.Substring(0, _input.Length - 11);

        public string ActualChecksum
        {
            get
            {
                var length = _input.Length;
                return _input.Substring(length - 6, 5);
            }
        }

        public string ExpectedChecksum
        {
            get
            {
                var counts = CalculateLetterFrequency();
                return new string(counts.OrderByDescending(
                    f => f, new FrequencyComparer()).Select(c => c.Letter).ToArray()).Substring(0,5);
            }
        }

        public string DecodedName
        {
            get
            {
                var sb = new StringBuilder(EncodedName.Length);
                foreach (var c in EncodedName)
                {
                    if (c != '-')
                    {
                        sb.Append((char)(((c - 'a' + SectorID)%26) + 'a'));
                    }
                    else
                    {
                        sb.Append(' ');
                    }
                }
                return sb.ToString();
            }
        }

        private IEnumerable<LetterFrequency> CalculateLetterFrequency()
        {
            var letterFrequency = new Dictionary<char, int>();
            foreach (var c in EncodedName)
            {
                if (c == '-')
                    continue;

                if (!letterFrequency.ContainsKey(c))
                {
                    letterFrequency.Add(c, 0);
                }

                letterFrequency[c]++;
            }

            return ConvertLetterFrequencyLookupToList(letterFrequency);
        }

        private static IEnumerable<LetterFrequency> ConvertLetterFrequencyLookupToList(Dictionary<char, int> letterFrequency)
        {
            var counts = new List<LetterFrequency>();
            foreach (var key in letterFrequency.Keys)
            {
                counts.Add(new LetterFrequency(key, letterFrequency[key]));
            }
            return counts;
        }


        public Room(string input)
        {
            _input = input;
        }

        public bool IsValid()
        {
            return ExpectedChecksum == ActualChecksum;
        }
    }
}
