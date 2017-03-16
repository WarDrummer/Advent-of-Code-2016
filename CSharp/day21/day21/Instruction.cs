namespace day21
{
    public abstract class Instruction
    {
        public static Instruction Create(string instructionText)
        {
            var parts = instructionText.Split(' ');
            if(instructionText.StartsWith("swap position"))
            {
                // swap position X with position Y
                return new SwapPositionInstruction(int.Parse(parts[2]), int.Parse(parts[5]));
            }
            
            if (instructionText.StartsWith("swap letter"))
            {
                //swap letter X with letter Y
                return new SwapLetterInstruction(parts[2][0], parts[5][0]);
            }

            if (instructionText.StartsWith("rotate left"))
            {
                // rotate left X steps
                return new RotateLeftInstruction(int.Parse(parts[2]));
            }

            if (instructionText.StartsWith("rotate right"))
            {
                // rotate right X steps
                return new RotateRightInstruction(int.Parse(parts[2]));
            }

            if (instructionText.StartsWith("rotate based"))
            {
                // rotate based on position of letter X
                return new RotateRightBasedOnIndexOfLetterInstruction(parts[6][0]);
            }

            if (instructionText.StartsWith("reverse"))
            {
                // reverse positions X through Y   
                return new ReverseInstruction(int.Parse(parts[2]), int.Parse(parts[4]));
            }

            if (instructionText.StartsWith("move"))
            {
                // move position X to position Y
                return new MoveInstruction(int.Parse(parts[2]), int.Parse(parts[5]));
            }

            return new NoOpInstruction();
        }

        public static Instruction CreateReverse(string instructionText)
        {
            var parts = instructionText.Split(' ');
            if (instructionText.StartsWith("swap position"))
            {
                return new SwapPositionInstruction(int.Parse(parts[5]), int.Parse(parts[2]));
            }

            if (instructionText.StartsWith("swap letter"))
            {
                return new SwapLetterInstruction(parts[5][0], parts[2][0]);
            }

            if (instructionText.StartsWith("rotate left"))
            {
                return new RotateRightInstruction(int.Parse(parts[2]));
            }

            if (instructionText.StartsWith("rotate right"))
            {
                return new RotateLeftInstruction(int.Parse(parts[2]));
            }

            if (instructionText.StartsWith("rotate based"))
            {
                return new ReverseRotateRightBasedOnIndexOfLetterInstruction(parts[6][0]);
            }

            if (instructionText.StartsWith("reverse"))
            { 
                return new ReverseInstruction(int.Parse(parts[2]), int.Parse(parts[4]));
            }

            if (instructionText.StartsWith("move"))
            {
                return new MoveInstruction(int.Parse(parts[5]), int.Parse(parts[2]));
            }

            return new NoOpInstruction();
        }

        public abstract string Mutate(string password);
    }
}