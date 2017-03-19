using System;
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
            var building = new Building(new[] {'L', 'H', 'M', 'Q' });
            building.SetMicrochipLocation(0, 'L');
            building.SetMicrochipLocation(2, 'H');
            building.SetMicrochipLocation(2, 'M');
            building.SetMicrochipLocation(3, 'Q');

            building.ElevatorLocation = 0;
            Assert.AreEqual(new [] {'L'}, building.GetMicrochipsOnCurrentFloor());

            building.ElevatorLocation = 2;
            Assert.AreEqual(new[] { 'H', 'M' }, building.GetMicrochipsOnCurrentFloor());

            building.ElevatorLocation = 3;
            Assert.AreEqual(new[] { 'Q' }, building.GetMicrochipsOnCurrentFloor());
        }

        [Test]
        public void get_generators_for_floor()
        {
            var building = new Building(new[] { 'L', 'H', 'M', 'Q' });
            building.SetGeneratorLocation(0, 'L');
            building.SetGeneratorLocation(2, 'H');
            building.SetGeneratorLocation(2, 'M');
            building.SetGeneratorLocation(3, 'Q');

            building.ElevatorLocation = 0;
            Assert.AreEqual(new[] { 'L' }, building.GetGeneratorsOnCurrentFloor());

            building.ElevatorLocation = 2;
            Assert.AreEqual(new[] { 'H', 'M' }, building.GetGeneratorsOnCurrentFloor());

            building.ElevatorLocation = 3;
            Assert.AreEqual(new[] { 'Q' }, building.GetGeneratorsOnCurrentFloor());
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
