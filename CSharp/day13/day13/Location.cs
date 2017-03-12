using System;
using System.Linq;

namespace day13
{
    public abstract class Location
    {
        public abstract bool IsPassable { get; }

        public static int FavoriteNumber = 10;

        public static Location Create(int x, int y)
        {
            var value = (x*x + 3*x + 2*x*y + y + y*y) + FavoriteNumber;
            var binary = Convert.ToString(value, 2);
            var ones = binary.Count(c => c == '1');
            return (ones%2 == 0) ? (Location) new OpenSpace() : new Wall();
        }  
    }
}