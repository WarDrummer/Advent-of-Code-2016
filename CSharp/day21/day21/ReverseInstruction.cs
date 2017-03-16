using System;

namespace day21
{
    public class ReverseInstruction : Instruction
    {
        private readonly int _x;
        private readonly int _y;

        public ReverseInstruction(int x, int y)
        {
            _x = x;
            _y = y;
        }

        // reverse positions X through Y means that the span of letters 
        // at indexes X through Y (including the letters at X and Y) should 
        // be reversed in order
        public override string Mutate(string password)
        {
            var begin = password.Substring(0, _x);
            var middle = password.Substring(_x, _y - _x + 1).ToCharArray();
            Array.Reverse(middle);
            var end = password.Substring(Math.Min(_y + 1, password.Length - 1), password.Length - _y - 1);
            return $"{begin}{new string(middle)}{end}";
        }
    }
}