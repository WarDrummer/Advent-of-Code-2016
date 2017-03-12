using NUnit.Framework;

namespace day11
{
    // ReSharper disable once InconsistentNaming
    public class Building_should_
    {
        [Test]
        public void convert_to_readable_string()
        {
            var building = new Building(new [] {'L', 'H'});
            Assert.AreEqual(
                "F4 .  .  .  .  .  \r\nF3 .  .  .  .  .  \r\nF2 .  .  .  .  .  \r\nF1 E  .  .  .  .  \r\n", 
                building.ToString());
        }
    }
}
