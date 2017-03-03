using System.Collections.Generic;
using NUnit.Framework;

namespace day7
{
    // ReSharper disable once InconsistentNaming
    internal class IPv7
    {
        private readonly string _input;

        private readonly List<string> _nonHyperNet = new List<string>();
        private readonly List<string> _hyperNet = new List<string>();

        public IPv7(string input)
        {
            _input = input;
            BreakIntoSubComponents();
        }

        private void BreakIntoSubComponents()
        {
            var firstSplit = _input.Split('[');
            _nonHyperNet.Add(firstSplit[0]);
            for (var i = 1; i < firstSplit.Length; i++)
            {
                var newSplit = firstSplit[i].Split(']');
                _hyperNet.Add(newSplit[0]);
                _nonHyperNet.Add(newSplit[1]);
            }
        }

        public bool SupportsTls()
        {
            foreach (var h in _hyperNet)
            {
                if (PalindromeFinder.HasPalindrome(h))
                    return false;
            }

            foreach (var h in _nonHyperNet)
            {
                if (PalindromeFinder.HasPalindrome(h))
                    return true;
            }

            return false;
        }

        public bool SupportsSsl()
        {
            var hyperNetTriplets = new HashSet<string>();

            foreach (var h in _hyperNet)
            {
                foreach (var triplet in GetTriplets(h))
                {
                    hyperNetTriplets.Add(triplet);
                }
            }

            foreach (var h in _nonHyperNet)
            {
                foreach (var triplet in GetInvertedTriplets(h))
                {
                    if (hyperNetTriplets.Contains(triplet))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static IEnumerable<string> GetTriplets(string s)
        {
            for (var i = 0; i <= s.Length - 3; i++)
            {
                if (s[i] != s[i + 1] && s[i] == s[i + 2])
                {
                    yield return new string(new[] {s[i], s[i + 1], s[i + 2]});
                }
            }
        }

        private static IEnumerable<string> GetInvertedTriplets(string s)
        {
            for (var i = 0; i <= s.Length - 3; i++)
            {
                if (s[i] != s[i + 1] && s[i] == s[i + 2])
                {
                    yield return new string(new[] { s[i+1], s[i], s[i + 1] });
                }
            }
        }
    }
}
