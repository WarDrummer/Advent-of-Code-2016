namespace day25
{
    public class CopyInstruction : Instruction
    {
        private readonly int _copyToRegisterIndex;
        private readonly string _valueOrRegister;

        public CopyInstruction(string valueOrRegister, string register)
        {
            _valueOrRegister = valueOrRegister;
            _copyToRegisterIndex = GetRegisterIndex(register[0]);
        }

        public override void Execute(Computer computer)
        {
            var valueToAdd = ValueOrValueFromRegister(computer, _valueOrRegister);

            computer.Registers[_copyToRegisterIndex] = valueToAdd;

            base.Execute(computer);
        }   
    }
}