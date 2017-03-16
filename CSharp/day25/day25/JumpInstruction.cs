namespace day25
{
    public class JumpInstruction : Instruction
    {
        private readonly string _valueOrValueFromRegister;
        private readonly int _offset;

        public JumpInstruction(string valueOrRegister, string offset)
        {
            _valueOrValueFromRegister = valueOrRegister;
            _offset = int.Parse(offset);
        }

        public override void Execute(Computer computer)
        {
            var value = ValueOrValueFromRegister(computer, _valueOrValueFromRegister);

            if (value == 0)
                computer.InstructionPointer++;
            else
                computer.InstructionPointer += _offset;
        }
    }
}