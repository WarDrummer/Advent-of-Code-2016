namespace day23
{
    public class ToggleInstruction : Instruction
    {
        private readonly string _valueOrRegister;

        public ToggleInstruction(string valueOrRegister)
        {
            _valueOrRegister = valueOrRegister;
        }

        public override void Execute(Computer computer)
        {
            var offset = ValueOrValueFromRegister(computer, _valueOrRegister);
            var index = computer.InstructionPointer + offset;
            if (index < computer.Instructions.Length)
            {
                computer.Instructions[index] = computer.Instructions[index].Toggle();
            }

            base.Execute(computer);
        }

        public override Instruction Toggle()
        {
            return new IncrementInstruction(_valueOrRegister);
        }
    }
}