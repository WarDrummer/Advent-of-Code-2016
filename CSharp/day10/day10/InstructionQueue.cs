using System.Collections.Generic;

namespace day10
{
    public class InstructionQueue
    {
        private static readonly Queue<BotInstruction> Instructions = new Queue<BotInstruction>();

        public void AddInstruction(BotInstruction instruction)
        {
            Instructions.Enqueue(instruction);
        }

        public void ExecuteInstructions()
        {
            while (Instructions.Count > 0)
            {
                Instructions.Dequeue().Execute();
            }
        }
    }
}