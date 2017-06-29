using NUnit.Framework;

namespace day11
{
    // ReSharper disable once InconsistentNaming
    public class Building_should_
    {
        [Test]
        public void convert_to_readable_string()
        {
            var building = new Building(new [] {'L', 'H'}, 0);
            Assert.AreEqual(
                "F4 .  .  .  .  .  \r\nF3 .  .  .  .  .  \r\nF2 .  .  .  .  .  \r\nF1 E  LM LG HM HG \r\n", 
                building.ToString());
        }

        [TestCase('L', 0)]
        [TestCase('H', 1)]
        [TestCase('M', 2)]
        [TestCase('Q', 3)]
        public void should_update_microchip_location(char element, int floor)
        {
            var building = new Building(new[] { element, (char)(element + 1) });
            building.SetMicrochipLocation(floor, element);
            Assert.AreEqual(floor, building.GetMicrochipLocation(element));
        }

        [TestCase('L', 0)]
        [TestCase('H', 1)]
        [TestCase('M', 2)]
        [TestCase('Q', 3)]
        public void update_generator_location(char element, int floor)
        {
            var building = new Building(new[] { element, (char)(element + 1) });
            building.SetGeneratorLocation(floor, element);
            Assert.AreEqual(floor, building.GetGeneratorLocation(element));
        }

        [Test]
        public void get_microchips_for_floor()
        {
            var buildingAt0 = new Building(new[] {'L', 'H', 'M', 'Q' }, 0);
            buildingAt0.SetMicrochipLocation(0, 'L');
            buildingAt0.SetMicrochipLocation(2, 'H');
            buildingAt0.SetMicrochipLocation(2, 'M');
            buildingAt0.SetMicrochipLocation(3, 'Q');
            Assert.AreEqual(new [] {'L'}, buildingAt0.GetMicrochipsOnCurrentFloor());

            var buildingAt2 = new Building(new[] { 'L', 'H', 'M', 'Q' }, 2);
            buildingAt2.SetMicrochipLocation(0, 'L');
            buildingAt2.SetMicrochipLocation(2, 'H');
            buildingAt2.SetMicrochipLocation(2, 'M');
            buildingAt2.SetMicrochipLocation(3, 'Q');
            Assert.AreEqual(new[] { 'H', 'M' }, buildingAt2.GetMicrochipsOnCurrentFloor());

            var buildingAt3 = new Building(new[] { 'L', 'H', 'M', 'Q' }, 3);
            buildingAt3.SetMicrochipLocation(0, 'L');
            buildingAt3.SetMicrochipLocation(2, 'H');
            buildingAt3.SetMicrochipLocation(2, 'M');
            buildingAt3.SetMicrochipLocation(3, 'Q');
            Assert.AreEqual(new[] { 'Q' }, buildingAt3.GetMicrochipsOnCurrentFloor());
        }

        [Test]
        public void get_generators_for_floor()
        {
            var buildingAt0 = new Building(new[] { 'L', 'H', 'M', 'Q' });
            buildingAt0.SetGeneratorLocation(0, 'L');
            buildingAt0.SetGeneratorLocation(2, 'H');
            buildingAt0.SetGeneratorLocation(2, 'M');
            buildingAt0.SetGeneratorLocation(3, 'Q');
            Assert.AreEqual(new[] { 'L' }, buildingAt0.GetGeneratorsOnCurrentFloor());

            var buildingAt2 = new Building(new[] { 'L', 'H', 'M', 'Q' }, 2);
            buildingAt2.SetGeneratorLocation(0, 'L');
            buildingAt2.SetGeneratorLocation(2, 'H');
            buildingAt2.SetGeneratorLocation(2, 'M');
            buildingAt2.SetGeneratorLocation(3, 'Q');
            Assert.AreEqual(new[] { 'H', 'M' }, buildingAt2.GetGeneratorsOnCurrentFloor());

            var buildingAt3 = new Building(new[] { 'L', 'H', 'M', 'Q' }, 3);
            buildingAt3.SetGeneratorLocation(0, 'L');
            buildingAt3.SetGeneratorLocation(2, 'H');
            buildingAt3.SetGeneratorLocation(2, 'M');
            buildingAt3.SetGeneratorLocation(3, 'Q');
            Assert.AreEqual(new[] { 'Q' }, buildingAt3.GetGeneratorsOnCurrentFloor());
        }

        [Test]
        public void be_invalid_if_unshielded_microchip_on_same_floor_with_unmatching_generator()
        {
            var building = new Building(new [] {'L', 'H'});
            building.SetMicrochipLocation(2, 'L');
            building.SetGeneratorLocation(2, 'H');
            Assert.IsFalse(building.IsValid());
        }

        [Test]
        public void be_valid_if_shielded_microchip_on_same_floor_with_unmatching_generator()
        {
            var building = new Building(new[] { 'L', 'H' });
            building.SetMicrochipLocation(2, 'L');
            building.SetGeneratorLocation(2, 'L');
            building.SetGeneratorLocation(2, 'H');
            Assert.IsTrue(building.IsValid());
        }  
    }
}
