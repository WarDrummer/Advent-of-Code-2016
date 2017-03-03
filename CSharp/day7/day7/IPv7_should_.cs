using NUnit.Framework;

namespace day7
{
    public class IPv7_should_
    {
        [TestCase("abba[mnop]qrst", true)]
        [TestCase("abba[mnop]qrst[mnop]qrst", true)]
        [TestCase("qrst[mnop]abba", true)]
        [TestCase("aergaergabba[srths5mnop]srthhshqrst", true)]
        [TestCase("abcd[bddb]xyyx", false)]
        [TestCase("abcd[bddb]xyyx[bddb]xyyx", false)]
        [TestCase("xyyx[bddb]abcd", false)]
        [TestCase("[bddb]xyyxabcd", false)]
        [TestCase("xyyxabcd[bddb]", false)]
        [TestCase("aerh5abcdaerhaer[aegrebddbgea4]aegr4xyyxhae", false)]
        [TestCase("aaaa[qwer]tyui", false)]
        [TestCase("[qwer]aaaa[qwer]tyui", false)]
        [TestCase("aaaa[qwer]tyui[qwer]", false)]
        [TestCase("ioxxoj[asdfgh]zxcvbn", true)]
        [TestCase("[asdfgh]ioxxoj[asdfgh]zxcvbn", true)]
        public void correctly_determine_tls_support(string address, bool expectedResult)
        {
            var ip = new IPv7(address);  
            Assert.AreEqual(expectedResult, ip.SupportsTls()); 
        }

        [TestCase("aba[bab]xyz", true)]
        [TestCase("xyx[xyx]xyx", false)]
        [TestCase("aaa[kek]eke", true)]
        [TestCase("zazbz[bzb]cdb", true)]
        public void correctly_determine_ssl_support(string address, bool expectedResult)
        {
            var ip = new IPv7(address);
            Assert.AreEqual(expectedResult, ip.SupportsSsl());
        }
    }
}
