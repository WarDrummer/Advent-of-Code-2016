using System.Collections.Generic;
using System.Linq;
using Tools;

namespace day14
{
    class KeyGenerator
    {
        private readonly Dictionary<char, List<int>> _lastSeen = new Dictionary<char, List<int>>();

        public int GetIndexOfHashProducing64ThKey(string seed)
        {
            
            var found = 0;
            for (var i = 0; i < int.MaxValue; i++)
            {
                var previous = '\0';
                var previousCount = 1;
                var firstTriplet = '\0';
                // var md5 = new string(Md5Stringifier.GetHexCharacters($"{seed}{i}").ToArray());
                // Console.WriteLine($"{i}: {md5}");
                foreach (var current in Md5Stringifier.GetHexCharacters($"{seed}{i}"))
                {
                    if (current == previous)
                    {
                        previousCount++;

                        // only consider first triplet for each hash
                        if (previousCount == 3 && firstTriplet == '\0')
                        {
                            firstTriplet = current;
                            if (!_lastSeen.ContainsKey(current))
                            {
                                _lastSeen[current] = new List<int>();
                            }
                            _lastSeen[current].Add(i);
                            //   Console.WriteLine($"First triple for i{i}={current}{current}{current}");
                        }
                        else if (previousCount == 5 && _lastSeen.ContainsKey(current))
                        {
                            // count all hashes found in the last 1000 
                            found += _lastSeen[current]
                                .Count(previousTripletIndex => previousTripletIndex != i &&
                                                               i - previousTripletIndex <= 1000);

                            if (found >= 64)
                            {
                                return i;
                            }

                            // remove counted hashes
                            //lastSeen[current].RemoveAll(previousTripletIndex => previousTripletIndex != i &&
                            //                                                  i - previousTripletIndex <= 1000);   
                        }
                    }
                    else
                    {
                        previous = current;
                        previousCount = 1;
                    }
                }
            }
            return -1;
        }
    }
}