using NUnit.Framework;

namespace day21
{
    // ReSharper disable once InconsistentNaming
    class MoveInstruction_should_
    {
        [TestCase("bcdea", 1, 4, "bdeac")]
        [TestCase("abc", 0, 2, "bca")]
        [TestCase("abc", 2, 0, "cab")]
        public void relocate_char_at_x_to_y(string start, int x, int y, string expected)
        {
            Assert.AreEqual(expected, new MoveInstruction(x, y).Mutate(start));
        }
    }
}
