namespace day21
{
    public class ReverseRotateRightBasedOnIndexOfLetterInstruction : Instruction
    {
        private readonly char _letter;

        public ReverseRotateRightBasedOnIndexOfLetterInstruction(char letter)
        {
            _letter = letter;
        }

        // rotate based on position of letter X means that the whole string should 
        // be rotated to the right based on the index of letter X(counting from 0) as 
        // determined before this instruction does any rotations. Once the index is determined, 
        // rotate the string to the right one time, plus a number of times equal to that index, 
        // plus one additional time if the index was at least 4.
        public override string Mutate(string password)
        {
            var index = password.IndexOf(_letter);
            var rotation = index / 2 + (index % 2 != 0 || index == 0 ? 1 : 5);
            return new RotateLeftInstruction(rotation).Mutate(password);
        }
    }
}