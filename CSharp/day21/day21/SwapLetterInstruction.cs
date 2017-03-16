namespace day21
{
    public class SwapLetterInstruction : Instruction
    {
        private readonly char _x;
        private readonly char _y;

        public SwapLetterInstruction(char x, char y)
        {
            _x = x;
            _y = y;
        }

        // swap letter X with letter Y means that the letters X and Y should 
        // be swapped (regardless of where they appear in the string)
        public override string Mutate(string password)
        {
            var indexOfX = password.IndexOf(_x);
            var indexOfY = password.IndexOf(_y);
            var p = password.ToCharArray();
            p[indexOfX] = _y;
            p[indexOfY] = _x;
            return new string(p);
        }
    }
}