namespace day24
{
    public class Location
    {
        public long X { get; }
        public long Y { get; }

        public Location(long x, long y)
        {
            X = x;
            Y = y;
        }

        private const int Shift = sizeof(int)*8;

        public bool IsEqualTo(Location location)
        {
            return UniqueIdentifier== location?.UniqueIdentifier;
        }

        public long UniqueIdentifier => (X << Shift) + Y;
    }
}