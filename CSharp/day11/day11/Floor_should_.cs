using NUnit.Framework;

namespace day11
{
    // ReSharper disable once InconsistentNaming
    public class Floor_should_
    {
        [Test]
        public void convert_to_readable_string()
        {
            var floor = new Floor(new []{'L', 'H'}, new []{'H'}, new []{'L'});
            Assert.AreEqual("LG .  .  HM ", floor.ToString());
        }

        [Test]
        public void detect_valid_floors()
        {
            var floor = new Floor(new[] { 'L', 'H' }, new[] { 'H' }, new[] { 'H', 'L' });
            Assert.IsTrue(floor.IsValid());
        }
    }
}
 