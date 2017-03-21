namespace day19
{
    public class Elf
    {
        public int Id { get; }
        public Elf NextElf { get; set; }

        public Elf(int id)
        {
            Id = id;
        }
    }
}