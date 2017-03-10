namespace day10
{
    public class NullBotInstruction : BotInstruction
    {
        public NullBotInstruction() : base(string.Empty, string.Empty, string.Empty)
        {
        }

        public override void Execute()
        {
            // Do nothing
        }
    }
}