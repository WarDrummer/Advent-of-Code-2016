namespace day12
{
    public abstract class Instruction
    {
        public static Instruction Create(string instruction)
        {
            var components = instruction.Split(' ');

            switch (components[0])
            {
                case "inc":
                    return new IncrementInstruction(components[1]);
                case "dec":
                    return new DecrementInstruction(components[1]);
                case "cpy":
                    return new CopyInstruction(components[1], components[2]);
                case "jnz":
                    return new JumpInstruction(components[1], components[2]);
                default:
                    return new NopInstruction();
            }
        }

        public virtual void Execute(Computer computer)
        {
            computer.InstructionPointer++;
        }

        public static int GetRegisterIndex(char registerName)
        {
            return registerName - 'a';
        }

        public long ValueOrValueFromRegister(Computer computer, string valueOrRegister)
        {
            int value;
            if (int.TryParse(valueOrRegister, out value))
                return value;

            var registerIndex = GetRegisterIndex(valueOrRegister[0]);
            return computer.Registers[registerIndex];
        }
    }
}