namespace day23
{
    public class JumpInstruction : Instruction
    {
        private readonly string _valueOrValueFromRegister;
        private readonly string _offsetOrOffsetFromRegister;

        public JumpInstruction(string valueOrRegister, string offsetOrOffsetFromRegisterOrOffsetOrOffsetFromRegisterFromRegister)
        {
            _valueOrValueFromRegister = valueOrRegister;
            _offsetOrOffsetFromRegister = offsetOrOffsetFromRegisterOrOffsetOrOffsetFromRegisterFromRegister;
        }

        public override void Execute(Computer computer)
        {
            var value = ValueOrValueFromRegister(computer, _valueOrValueFromRegister);
            var offset = ValueOrValueFromRegister(computer, _offsetOrOffsetFromRegister);

            if (value == 0)
                computer.InstructionPointer++;
            else
                computer.InstructionPointer += offset;
        }

        public override Instruction Toggle()
        {
            return new CopyInstruction(_valueOrValueFromRegister, _offsetOrOffsetFromRegister);
        }
    }
}