using System.Collections.Generic;
using System.Linq;

namespace day24
{
    class Permutation
    {
        public static IEnumerable<List<T>> GetPermutations<T>(List<T> items)
        {
            if (items.Count == 1)
            {
                yield return items;
            }
            else
            {
                for (var i = 0; i < items.Count; i++)
                {
                    foreach (var permutation in GetPermutations(items.Where((value, index) => index != i).ToList()))
                    {
                        permutation.Insert(0, items[i]);
                        yield return permutation;
                    }
                }
            }
        }
    }
}