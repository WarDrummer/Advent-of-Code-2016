using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day10
{
    public class ChipStorage
    {
        private static readonly Dictionary<string, List<int>> ChipCache = new Dictionary<string, List<int>>();
        private static readonly Dictionary<string, string> Comparisons = new Dictionary<string, string>();

        public int GetNumberOfChipsFor(string id)
        {
            return ChipCache.ContainsKey(id) ? ChipCache[id].Count : 0;
        }

        public int GetHighChipFrom(string id)
        {
            RecordComparisons(id);

            var max = ChipCache[id].Max();
            ChipCache[id].Remove(max);
            return max;
        } 

        public int GetLowChipFrom(string id)
        {
            RecordComparisons(id);

            var min = ChipCache[id].Min();
            ChipCache[id].Remove(min);
            return min;
        }

        public void GiveChipTo(string id, int chip)
        {
            if (!ChipCache.ContainsKey(id))
            {
                ChipCache.Add(id, new List<int>());
            }

            ChipCache[id].Add(chip);

            if (id.StartsWith("bot") && ChipCache[id].Count == 2)
            {
                var instruction = new BotInstructionCache().GetBotInstructionFor(id);
                new InstructionQueue().AddInstruction(instruction);
            }
        }

        public string WhoCompared(int chip1, int chip2)
        {
            var lookup = StringifyComparison(chip1, chip2);
            return Comparisons.ContainsKey(lookup) ? Comparisons[lookup] : "No comparison made";
        }

        private static void RecordComparisons(string id)
        {
            var chips = ChipCache[id];
            if(chips.Count < 2)  return;
            
            var chip1 = chips[0];
            var chip2 = chips[1];
            Comparisons[StringifyComparison(chip1, chip2)] = id;
            Comparisons[StringifyComparison(chip1, chip2)] = id;
        }

        private static string StringifyComparison(int chip1, int chip2)
        {
            return $"{chip1},{chip2}";
        }

        public string GetBinValues(params int[] binIds)
        {
            var sb = new StringBuilder();
            foreach (var binId in binIds)
            {
                var lookup = MasterControlProgram.BinId(binId.ToString());
                sb.AppendLine($"{lookup}: {string.Join(", ", ChipCache[lookup])}");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var key in ChipCache.Keys)
            {
                sb.AppendLine($"{key}: {string.Join(", ", ChipCache[key])}");
            }
            return sb.ToString();
        }
    }
}