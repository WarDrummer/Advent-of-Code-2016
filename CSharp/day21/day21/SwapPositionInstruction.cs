namespace day21
{
    public class SwapPositionInstruction : Instruction
    {
        private readonly int _x;
        private readonly int _y;

        public SwapPositionInstruction(int x, int y)
        {
            _x = x;
            _y = y;
        }

        // swap position X with position Y means that the letters at
        // indexes X and Y(counting from 0) should be swapped
        public override string Mutate(string password)
        {
            var letterAtX = password[_x];
            var letterAtY = password[_y];
            var p = password.ToCharArray();
            p[_x] = letterAtY;
            p[_y] = letterAtX;
            return new string(p);
        }
    }
}