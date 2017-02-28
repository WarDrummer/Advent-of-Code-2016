using System;

namespace day12
{
    public class NopInstruction : Instruction
    {
        public override void Execute(Computer computer)
        {
            throw new InvalidOperationException("Nope");
        }
    }
}