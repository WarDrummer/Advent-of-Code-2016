using System.Collections.Generic;
using Tools;

namespace day14
{
    class KeyGenerator
    {
        private readonly Dictionary<char, List<int>> _quintIndexes = new Dictionary<char, List<int>>();

        public static char GetFirstTripletMatch(string md5)
        {
            var previous = '\0';
            var previousCount = 1;

            foreach (var c in md5)
            {
                if (previous == c)
                {
                    previousCount++;
                    if (previousCount == 3)
                        return c;
                }
                else
                {
                    previous = c;
                    previousCount = 1;
                }
            }

            return '\0';
        }

        public static IEnumerable<char> GetAllQuintMatches(string md5)
        {
            var previous = '\0';
            var previousCount = 1;

            foreach (var c in md5)
            {
                if (previous == c)
                {
                    previousCount++;
                    if (previousCount == 5)
                        yield return c;
                }
                else
                {
                    previous = c;
                    previousCount = 1;
                }
                    
            }
        }
        
        public int IndexOf64thKey(string seed)
        {
            var count = 0;
            for (var iteration = 0; iteration < int.MaxValue; iteration++)
            {
                var md5 = Get2016Hash($"{seed}{iteration}");

                foreach (var quint in GetAllQuintMatches(md5))
                {
                    if (!_quintIndexes.ContainsKey(quint))
                    {
                        _quintIndexes.Add(quint, new List<int>());
                    }
                    _quintIndexes[quint].Add(iteration);
                }

                if (iteration >= 1000)
                {
                    var previousIndex = iteration - 1000;
                    var previousMd5 = Get2016Hash($"{seed}{previousIndex}");
                    if (IsKey(previousMd5, previousIndex))
                    {
                        count++;
                        if (count == 64)
                            return previousIndex;
                    }
                }
            }

            return -1;
        }

        private Dictionary<string, string> _foundHashes = new Dictionary<string, string>();
        public string Get2016Hash(string seed)
        {
            if (_foundHashes.ContainsKey(seed))
                return _foundHashes[seed];

            var md5 = Md5Stringifier.GetMd5String(seed);
            for (int i = 0; i < 2016; i++)
            {
                md5 = Md5Stringifier.GetMd5String(md5);
            }

            _foundHashes.Add(seed, md5);
            return md5;
        }

        public bool IsKey(string md5, int tripletIndex)
        {
            var triplet = GetFirstTripletMatch(md5);
            if (triplet == '\0' || !_quintIndexes.ContainsKey(triplet))
            {
                return false;
            }

            return _quintIndexes[triplet].Exists(quintIndex =>
                (quintIndex - tripletIndex < 1000) && (quintIndex > tripletIndex));
        }
    }
}