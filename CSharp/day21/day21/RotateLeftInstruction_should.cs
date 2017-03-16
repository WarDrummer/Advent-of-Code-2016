using NUnit.Framework;

namespace day21
{
    // ReSharper disable once InconsistentNaming
    class RotateLeftInstruction_should
    {
        [TestCase("abcde", 1, "bcdea")]
        [TestCase("abcde", 2, "cdeab")]
        public void shift_chars_left(string start, int steps, string expected)
        {
            Assert.AreEqual(expected, new RotateLeftInstruction(steps).Mutate(start));
        }
    }
}
