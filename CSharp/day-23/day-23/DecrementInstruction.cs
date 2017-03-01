namespace day23
{
    public class DecrementInstruction : Instruction
    {
        private readonly string _register;

        public DecrementInstruction(string register)
        {
            _register = register;
        }

        public override void Execute(Computer computer)
        {
            var registerIndex = GetRegisterIndex(_register[0]);
            computer.Registers[registerIndex]--;
            base.Execute(computer);
        }

        public override Instruction Toggle()
        {
            return new IncrementInstruction(_register);
        }
    }
}