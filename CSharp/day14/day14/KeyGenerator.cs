using System.Collections.Generic;
using Tools;

namespace day14
{
    class KeyGenerator
    {
        private readonly Dictionary<char, List<int>> _lastSeen = new Dictionary<char, List<int>>();

        public int GetIndexOfHashProducing64ThKey(string seed)
        {
            var numberOfKeysFounds = 0;
            for (var iteration = 0; iteration < int.MaxValue; iteration++)
            {
                var previous = '\0';
                var previousCount = 1;
                var firstTriplet = '\0';

                foreach (var current in Md5Stringifier.GetHexCharacters($"{seed}{iteration}"))
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
                            _lastSeen[current].Add(iteration);
                        }
                        else if (previousCount == 5 && _lastSeen.ContainsKey(current))
                        {
                            for (var x = 0; x < _lastSeen[current].Count; x++)
                            {
                                if (iteration != _lastSeen[current][x] &&
                                    iteration - _lastSeen[current][x] <= 1000)
                                {
                                    numberOfKeysFounds++;
                                    if (numberOfKeysFounds == 64)
                                    {
                                        return _lastSeen[current][x];
                                    }
                                }
                            }  
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