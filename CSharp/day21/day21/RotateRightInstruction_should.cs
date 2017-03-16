using NUnit.Framework;

namespace day21
{
    class RotateRightInstruction_should
    {

        [TestCase("abcde", 1, "eabcd")]
        [TestCase("abcde", 2, "deabc")]
        public void shift_chars_right(string start, int steps, string expected)
        {
            Assert.AreEqual(expected, new RotateRightInstruction(steps).Mutate(start));
        }
    }
}
