namespace day12
{
    public class DecrementInstruction : Instruction
    {
        private readonly int _registerIndex;

        public DecrementInstruction(string register)
        {
            _registerIndex = GetRegisterIndex(register[0]);
        }

        public override void Execute(Computer computer)
        {
            computer.Registers[_registerIndex]--;
            base.Execute(computer);
        }
    }
}