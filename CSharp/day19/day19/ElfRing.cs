namespace day19
{
    public class ElfRing
    {
        public static int Part1(int numberOfElves)
        {
            var elf = BuildElfRing(numberOfElves);
            while (elf != elf.NextElf)
            {
                elf.NextElf = elf.NextElf.NextElf;
                elf = elf.NextElf;
            }
            return elf.Id;
        }

        public static int Part2(int numberOfElves)
        {
            var elfCount = numberOfElves;
            var elf = BuildElfRing(elfCount);

            var firstRemoval = (elfCount / 2) - 1;
            var elfPriorToRemoval = elf;

            for (var i = 0; i < firstRemoval; i++)
                elfPriorToRemoval = elfPriorToRemoval.NextElf;

            if (elfCount % 2 == 1) // odd
            {
                elfPriorToRemoval.NextElf = elfPriorToRemoval.NextElf.NextElf;
                elfPriorToRemoval = elfPriorToRemoval.NextElf;
                elfCount--;
            }

            while (elfCount > 2)
            {
                elfPriorToRemoval.NextElf = elfPriorToRemoval.NextElf.NextElf;
                elfPriorToRemoval.NextElf = elfPriorToRemoval.NextElf.NextElf;
                elfPriorToRemoval = elfPriorToRemoval.NextElf;
                elfCount -= 2;
            }
            
            return elfPriorToRemoval.Id;
        }

        private static Elf BuildElfRing(int numberOfElves)
        {
            var firstElf = new Elf(1);
            var currentElf = firstElf;
            for (var i = 2; i <= numberOfElves; i++)
            {
                currentElf.NextElf = new Elf(i);
                currentElf = currentElf.NextElf;
            }
            currentElf.NextElf = firstElf;
            return firstElf;
        }
    }
}
