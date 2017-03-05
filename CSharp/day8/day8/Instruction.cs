namespace day8
{
    public abstract class Instruction
    {
        public abstract void Execute(LittleScreen screen);

        public static Instruction Create(string command)
        {
            if (command.StartsWith("rect"))
            {
                return RectInstruction.Parse(command);
            }

            if (command.StartsWith("rotate row"))
            {
                return RotateRowInstruction.Parse(command);
            }

            if (command.StartsWith("rotate column"))
            {
                return RotateColumnInstruction.Parse(command);
            }

            return null;
        }
    }
}