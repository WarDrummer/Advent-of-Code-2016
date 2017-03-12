using System.Collections.Generic;

namespace day13
{
    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinate[] GetValidAdjacentCoordinates()
        {
            var coords = new List<Coordinate>();

            if (X > 0)
            {
                coords.Add(new Coordinate(X - 1, Y));
            }

            if (X < int.MaxValue)
            {
                coords.Add(new Coordinate(X + 1, Y));
            }

            if (Y > 0)
            {
                coords.Add(new Coordinate(X, Y - 1));
            }

            if (Y < int.MaxValue)
            {
                coords.Add(new Coordinate(X, Y + 1));
            }

            return coords.ToArray();

        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}