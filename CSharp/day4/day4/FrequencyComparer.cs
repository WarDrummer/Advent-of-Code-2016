using System.Collections.Generic;

namespace day4
{
    public class FrequencyComparer : IComparer<LetterFrequency>
    {
        public int Compare(LetterFrequency x, LetterFrequency y)
        {
            if (x.Count == y.Count)
                return -(x.Letter - y.Letter);
            return x.Count > y.Count ? 1 : -1;
        }
    }
}