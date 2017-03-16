using System.Runtime.InteropServices;

namespace day25
{
    public class Computer
    {
        public int InstructionPointer = 0;
        private static readonly long[] DefaultRegisterValues = { 0, 0, 0, 0 };
        public long[] Registers = DefaultRegisterValues;
        private readonly Instruction[] _instructions;
        public readonly Clock Clock = new Clock();

        public Computer(Instruction[] instructions)
        {
            _instructions = instructions;
        }

        public void Run()
        {
            while (InstructionPointer < _instructions.Length && InstructionPointer > -1)
            {
                _instructions[InstructionPointer].Execute(this);
                if (Clock.NumberValidValues > 19)
                {
                    // we've repeated alternating 1s and 0s 20x
                    break;
                }
            }
        }

        public void Reset()
        {
            Registers = DefaultRegisterValues;
            InstructionPointer = 0;
            Clock.Reset();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", Registers)}], IP={InstructionPointer}";
        }
    }
}
