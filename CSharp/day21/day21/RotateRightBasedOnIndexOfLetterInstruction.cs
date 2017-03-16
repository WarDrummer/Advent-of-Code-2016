namespace day21
{
    public class RotateRightBasedOnIndexOfLetterInstruction : Instruction
    {
        private readonly char _letter;

        public RotateRightBasedOnIndexOfLetterInstruction(char letter)
        {
            _letter = letter;
        }

        // rotate based on position of letter X means that the whole string should 
        // be rotated to the right based on the index of letter X(counting from 0) as 
        // determined before this instruction does any rotations.Once the index is determined, 
        // rotate the string to the right one time, plus a number of times equal to that index, 
        // plus one additional time if the index was at least 4.
        public override string Mutate(string password)
        {
            var rotation = password.IndexOf(_letter);
            rotation += rotation >= 4 ? 2 : 1;
            return new RotateRightInstruction(rotation).Mutate(password);
        }
    }
}