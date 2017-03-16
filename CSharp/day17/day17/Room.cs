using System.Collections.Generic;
using Tools;

namespace day17
{
    public class Room
    {
        public string Passcode { get; }
        private readonly int _x;
        private readonly int _y;

        public Room(string passcode, int x, int y)
        {
            Passcode = passcode;
            _x = x;
            _y = y;
        }

        public IEnumerable<Room> GetUnlockedRooms()
        {
            var i = 0;
            foreach (var c in Md5Stringifier.GetHexCharacters(Passcode))
            {
                if (i == 0 && _y - 1 >= 0 && IsUnlocked(c))
                {
                    yield return new Room($"{Passcode}U", _x,  _y - 1);
                }
                else if (i == 1 && _y + 1 < 4 && IsUnlocked(c))
                {
                    yield return new Room($"{Passcode}D", _x, _y + 1);
                }
                else if (i == 2 && _x - 1 >= 0 && IsUnlocked(c))
                {
                    yield return new Room($"{Passcode}L", _x - 1, _y);
                }
                else if (i == 3 && _x + 1 < 4 && IsUnlocked(c))
                {
                    yield return new Room($"{Passcode}R", _x + 1, _y);
                }

                i += 1;
                if (i == 4) // Only need first for chars in hash
                    break;
            }
        }

        public bool IsGoal()
        {
            return _x == 3 && _y == 3;
        }

        public bool IsUnlocked(char c)
        {
            // b - f is unlocked
            return c > 'a' && c < 'g';
        }
    }
}