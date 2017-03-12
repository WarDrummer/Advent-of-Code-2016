namespace day13
{
    public class OpenSpace : Location
    {
        public override bool IsPassable { get; } = true;
        public override string ToString()
        {
            return ".";
        }
    }
}