namespace day12
{
    public class Computer
    {
        public int InstructionPointer = 0;
        public long[] Registers = { 0, 0, 1, 0 };
        private readonly Instruction[] _instructions;

        public Computer(Instruction[] instructions)
        {
            _instructions = instructions;
        }

        public void Run()
        {
            while (InstructionPointer < _instructions.Length && InstructionPointer > -1)
            {
                _instructions[InstructionPointer].Execute(this);
            }
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", Registers)}], IP={InstructionPointer}";
        }
    }
}
