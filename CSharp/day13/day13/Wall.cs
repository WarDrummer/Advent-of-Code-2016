namespace day13
{
    public class Wall : Location
    {
        public override bool IsPassable { get; } = false;

        public override string ToString()
        {
            return "#";
        }    
    }
}