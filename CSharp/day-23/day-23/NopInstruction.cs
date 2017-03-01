using System;

namespace day23
{
    public class NopInstruction : Instruction
    {
        public override void Execute(Computer computer)
        {
            throw new InvalidOperationException("Nope");
        }

        public override Instruction Toggle()
        {
            return this;
        }
    }
}