namespace day21
{
    public class RotateRightInstruction : Instruction
    {
        private readonly int _steps;

        public RotateRightInstruction(int steps)
        {
            _steps = steps;
        }

        // rotate left/right X steps means that the whole string should be rotated; for 
        // example, one right rotation would turn abcd into dabc.
        public override string Mutate(string password)
        {
            var rotated = new char[password.Length];
            var length = password.Length;
            var newIndex = password.Length - (_steps % password.Length);
            for (var i = 0; i < password.Length; i++, newIndex++)
            {
                rotated[i] = password[newIndex % length];
            }

            return new string(rotated);
        }
    }
}