using NUnit.Framework;

namespace day21
{
    // ReSharper disable once InconsistentNaming
    class ReverseInstruction_should_
    {
        [TestCase("abc", 0, 1, "bac")]
        [TestCase("abc", 1, 2, "acb")]
        [TestCase("abcd", 1, 2, "acbd")]
        public void reverse_substring(string start, int i1, int i2, string expected)
        {
            Assert.AreEqual(expected, new ReverseInstruction(i1, i2).Mutate(start));
        }

        [Test]
        public void be_undoable()
        {
            var x = 1;
            var y = 3;

            var password = "ajnierg";
            var encrypted = new ReverseInstruction(x, y).Mutate(password);

            Assert.AreEqual(password, new ReverseInstruction(x, y).Mutate(encrypted));
        }
    }
}
