using System.Diagnostics;

namespace day23
{
    public class Computer
    {
        public long InstructionPointer = 0;
        public long[] Registers = { 12, 0, 0, 0 };
        public readonly Instruction[] Instructions;

        public Computer(Instruction[] instructions)
        {
            Instructions = instructions;
        }

        public void Run()
        {
            while (InstructionPointer < Instructions.Length && InstructionPointer > -1)
            {
                Instructions[InstructionPointer].Execute(this);
                // Debug.WriteLine(ToString());
            }
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", Registers)}], IP={InstructionPointer}";
        }
    }
}
