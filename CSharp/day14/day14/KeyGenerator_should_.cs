using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace day14
{
    class KeyGenerator_should_
    {
        [TestCase("argarg", '\0')]
        [TestCase("aaac", 'a')]
        [TestCase("caaac", 'a')]
        [TestCase("bbbaaac", 'b')]
        public void find_first_triplet(string input, char triplet)
        {
            Assert.AreEqual(triplet, KeyGenerator.GetFirstTripletMatch(input));
        }

        [TestCase("aaaaa", 'a')]
        [TestCase("aaaaabbbbb", 'a', 'b')]
        [TestCase("xaaaaajbbbbbp", 'a', 'b')]
        [TestCase("oaerogijagr")]
        public void find_quint(string input, params char[] quint)
        {
            Assert.AreEqual(quint, KeyGenerator.GetAllQuintMatches(input).ToArray());
        }
    }
}
