using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day11
{
    public class Floor
    {
        private const string Absent = ".  ";

        private readonly List<char> _symbols;
        private readonly bool[] _generators;
        private readonly bool[] _microchips;

        public Floor(
            IReadOnlyCollection<char> symbols, 
            IEnumerable<char> microchips, 
            IEnumerable<char> generators)
        {
            _symbols = new List<char>(symbols);

            _microchips = new bool[symbols.Count];
            foreach (var chip in microchips)
            {
                var index = _symbols.IndexOf(chip);
                _microchips[index] = true;
            }

            _generators = new bool[symbols.Count];
            foreach (var generator in generators)
            {
                var index = _symbols.IndexOf(generator);
                _generators[index] = true;
            }
        }

        public Floor(
            IEnumerable<char> symbols, 
            bool[] microchips, 
            bool[] generators)
        {
            _symbols = new List<char>(symbols);
            _microchips = microchips;
            _generators = generators;
        }

        public IEnumerable<string[]> GetPossibleMoveCombinations()
        {
            for (var i = 0; i < _symbols.Count; i++)
            {
                // single chip
                if (_microchips[i])
                {
                    yield return new[] {AsMicrochip(_symbols[i])};

                    // loop chip, chip
                    for (var j = i + 1; j < _symbols.Count; j++)
                    {
                        if (_microchips[j])
                        {
                            yield return new[] {AsMicrochip(_symbols[i]), AsMicrochip(_symbols[j])};
                        }
                    }

                    // loop chip, generator
                    for (var j = i + 1; j < _symbols.Count; j++)
                    {
                        if (_generators[j])
                        {
                            yield return new[] { AsMicrochip(_symbols[i]), AsGenerator(_symbols[j]) };
                        }
                    }
                }

                // single generator
                if (_generators[i])
                {
                    yield return new[] {AsGenerator(_symbols[i])};

                    // loop gen, gen 
                    for (var j = i + 1; j < _symbols.Count; j++)
                    {
                        if (_generators[j])
                        {
                            yield return new[] { AsGenerator(_symbols[i]), AsGenerator(_symbols[j]) };
                        }
                    }
                }
            }
        }

        public Floor GetFloorWith(string[] items)
        {
            var generators = new bool[_generators.Length];
            var microchips = new bool[_microchips.Length];
            Array.Copy(_microchips, microchips, _microchips.Length);
            Array.Copy(_generators, generators, _generators.Length);

            foreach (var s in items)
            {
                if (s[1] == 'G')
                {
                    var i = _symbols.IndexOf(s[0]);
                    generators[i] = true;
                }
                else if (s[1] == 'M')
                {
                    var i = _symbols.IndexOf(s[0]);
                    microchips[i] = true;
                }
            }
            return new Floor(_symbols.ToArray(), microchips, generators);
        }

        public Floor GetFloorWithout(string[] symbols)
        {
            var generators = new bool[_generators.Length];
            var microchips = new bool[_microchips.Length];
            Array.Copy(_microchips, microchips, _microchips.Length);
            Array.Copy(_generators, generators, _generators.Length);

            foreach (var s in symbols)
            {
                if (s[1] == 'G')
                {
                    var i = _symbols.IndexOf(s[0]);
                    generators[i] = false;
                }
                else if (s[1] == 'M')
                {
                    var i = _symbols.IndexOf(s[0]);
                    microchips[i] = false;
                }
            }
            return new Floor(_symbols.ToArray(), microchips, generators);
        }

        public Floor Clone()
        {
            var generators = new bool[_symbols.Count];
            var microchips = new bool[_symbols.Count];
            Array.Copy(_microchips, microchips, _microchips.Length);
            Array.Copy(_generators, generators, _generators.Length);
            return new Floor(_symbols, microchips, generators);
        }

        public bool IsValid()
        {
            for (var i = 0; i < _symbols.Count; i++)
            {
                if (_microchips[i] && !_generators[i] && _generators.Count(g => g) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < _symbols.Count; i++)
            {
                sb.Append(_generators[i] ? AsGenerator(_symbols[i]) : Absent);
                sb.Append(_microchips[i] ? AsMicrochip(_symbols[i]) : Absent);
            }
            return sb.ToString();
        }

        private string AsMicrochip(char i)
        {
            return $"{i}M ";
        }

        private string AsGenerator(char i)
        {
            return $"{i}G ";
        }
    }
}