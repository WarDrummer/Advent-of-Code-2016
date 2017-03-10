namespace day10
{
    public class BotInstruction
    {
        private readonly string _fromBot;
        private readonly string _toLowId;
        private readonly string _toHighId;

        public BotInstruction(string fromBot, string toLowId, string toHighId)
        {
            _fromBot = fromBot;
            _toLowId = toLowId;
            _toHighId = toHighId;
        }

        public virtual void Execute()
        {
            var chipStorage = new ChipStorage();

            var highChip = chipStorage.GetHighChipFrom(_fromBot);
            var lowChip = chipStorage.GetLowChipFrom(_fromBot);

            chipStorage.GiveChipTo(_toLowId, lowChip);
            chipStorage.GiveChipTo(_toHighId, highChip);
        }
    }
}