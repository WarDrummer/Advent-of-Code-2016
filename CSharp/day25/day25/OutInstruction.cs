using System;

namespace day25
{
    public class OutInstruction : Instruction
    {
        private readonly int _registerIndex;

        public OutInstruction(string register)
        {
            _registerIndex = GetRegisterIndex(register[0]);
        }

        public override void Execute(Computer computer)
        {
            computer.Clock.Transmit(computer.Registers[_registerIndex]);
            base.Execute(computer);
        }
    }
}