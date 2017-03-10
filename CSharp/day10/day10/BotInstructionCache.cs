using System.Collections.Generic;

namespace day10
{
    public class BotInstructionCache
    {
        private static readonly Dictionary<string, BotInstruction> InstructionCache = new Dictionary<string, BotInstruction>();

        public void AddToCache(string botId, BotInstruction instruction)
        {
            InstructionCache[botId] = instruction;
        }

        public BotInstruction GetBotInstructionFor(string botId)
        {
            if (InstructionCache.ContainsKey(botId))
            {
                var instruction = InstructionCache[botId];
                InstructionCache.Remove(botId);
                return instruction;
            }

            return new NullBotInstruction();
        }
    }
}