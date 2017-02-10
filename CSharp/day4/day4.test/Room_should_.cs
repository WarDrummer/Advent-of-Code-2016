
using NUnit.Framework;

namespace day4.test
{
    // ReSharper disable once InconsistentNaming
    public class Room_should_
    {
        [Test]
        public void extract_encoded_room_name()
        {
            var input = "aaaaa-bbb-z-y-x-123[abxyz]";
            var roomName = new Room(input);
            Assert.AreEqual("aaaaa-bbb-z-y-x", roomName.EncodedName);
        }

        [Test]
        public void extract_checksum()
        {
            var input = "aaaaa-bbb-z-y-x-123[abxyz]";
            var roomName = new Room(input);
            Assert.AreEqual("abxyz", roomName.ActualChecksum);
        }

        [Test]
        public void extract_sector_id()
        {
            var input = "aaaaa-bbb-z-y-x-123[abxyz]";
            var roomName = new Room(input);
            Assert.AreEqual(123, roomName.SectorID);
        }

        [Test]
        public void order_actual_checksum_by_frequency()
        {
            var input = "aaaaa-bbbb-ccc-dd-e-739[abcde]";
            var roomName = new Room(input);
            Assert.AreEqual("abcde", roomName.ExpectedChecksum);
        }

        [Test]
        public void order_by_alpha_if_frequency_matches()
        {
            var input = "aaaaa-bbbb-e-d-c-532[abcde]";
            var roomName = new Room(input);
            Assert.AreEqual("abcde", roomName.ExpectedChecksum);
        }

        [TestCase("aaaaa-bbbb-e-d-c-982[abcde]")]
        [TestCase("aaaaa-bbb-z-y-x-123[abxyz]")]
        public void indicate_room_is_valid_when_checksums_match(string input)
        {
            var roomName = new Room(input);
            Assert.IsTrue(roomName.IsValid(), $"{roomName.ActualChecksum} != {roomName.ExpectedChecksum}");
        }

        [TestCase("aaaaa-bbbb-e-d-c-333[vwxyz]")]
        public void indicate_room_is_invalid_when_checksums_do_not_match(string input)
        {
            var roomName = new Room(input);
            Assert.IsFalse(roomName.IsValid());
        }

        [Test]
        public void decrypt_message()
        {
            var input = "qzmt-zixmtkozy-ivhz-343[abcde]";
            var room = new Room(input);
            Assert.AreEqual("very encrypted name", room.DecodedName);
        }
    }
}
