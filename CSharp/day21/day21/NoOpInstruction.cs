namespace day21
{
    public class NoOpInstruction : Instruction
    {
        public override string Mutate(string password)
        {
            return password;
        }
    }
}