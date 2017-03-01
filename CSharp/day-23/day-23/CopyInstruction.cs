namespace day23
{
    public class CopyInstruction : Instruction
    {
        private readonly string _register;
        private readonly string _valueOrRegister;

        public CopyInstruction(string valueOrRegister, string register)
        {
            _valueOrRegister = valueOrRegister;
            _register = register;
        }

        public override void Execute(Computer computer)
        {
            if (char.IsLetter(_register[0]))
            {
                var valueToAdd = ValueOrValueFromRegister(computer, _valueOrRegister);
                var registerIndex = GetRegisterIndex(_register[0]);

                computer.Registers[registerIndex] = valueToAdd;
            }

            base.Execute(computer);

        }

        public override Instruction Toggle()
        {
            return new JumpInstruction(_valueOrRegister, _register);
        }
    }
}