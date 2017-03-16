namespace day21
{
    public class RotateLeftInstruction : Instruction
    {
        private readonly int _steps;

        public RotateLeftInstruction(int steps)
        {
            _steps = steps;
        }

        // rotate left/right X steps means that the whole string should be rotated; for 
        // example, one right rotation would turn abcd into dabc.
        public override string Mutate(string password)
        {
            var rotated = new char[password.Length];
            var length = password.Length;
            var newIndex = (_steps % length);
            for (var i = 0; i < password.Length; i++, newIndex++)
            {
                rotated[i] = password[newIndex%length];
            }

            return new string(rotated);
        }
    }
}