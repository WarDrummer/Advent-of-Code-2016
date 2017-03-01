namespace day23
{
    public class IncrementInstruction : Instruction
    {
        private readonly string _register;

        public IncrementInstruction(string register)
        {
            _register = register;
        }

        public override void Execute(Computer computer)
        {
            var registerIndex = GetRegisterIndex(_register[0]);
            computer.Registers[registerIndex]++;
            base.Execute(computer);
        }

        public override Instruction Toggle()
        {
            return new DecrementInstruction(_register);
        }
    }
}