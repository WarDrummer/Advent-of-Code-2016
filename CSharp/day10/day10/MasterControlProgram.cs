namespace day10
{
    public class MasterControlProgram // (see Tron)
    {
        private static string BotId(string id)
        {
            return $"bot#{id}";
        }

        public static string BinId(string id)
        {
            return $"bin#{id}";
        }

        public static void Execute(string instruction)
        {
            var instructionQueue = new InstructionQueue();
            if (instruction.StartsWith("value"))
            {
                SendChipToRobot(instruction);
            }
            else
            {
                var parts = instruction.Split(' ');
                var fromRobotId = BotId(parts[1]);
                var toLowId = (parts[5] == "bot") ? BotId(parts[6]) : BinId(parts[6]);
                var toHighId = (parts[10] == "bot") ? BotId(parts[11]) : BinId(parts[11]);

                if (new ChipStorage().GetNumberOfChipsFor(fromRobotId) > 1)
                {
                    new InstructionQueue().AddInstruction(new BotInstruction(fromRobotId, toLowId, toHighId));
                }
                else
                {
                    new BotInstructionCache().AddToCache(
                        fromRobotId,
                        new BotInstruction(fromRobotId, toLowId, toHighId));
                }
            }

            instructionQueue.ExecuteInstructions();
        }

        private static void SendChipToRobot(string instruction)
        {
            var parts = instruction.Split(' ');
            var chipId = int.Parse(parts[1]);
            new ChipStorage().GiveChipTo(BotId(parts[5]), chipId);
        }
    }
}