namespace day25
{
    public class IncrementInstruction : Instruction
    {
        private readonly int _registerIndex;

        public IncrementInstruction(string register)
        {
            _registerIndex = GetRegisterIndex(register[0]);
        }

        public override void Execute(Computer computer)
        {
            computer.Registers[_registerIndex]++;
            base.Execute(computer);
        }
    }
}