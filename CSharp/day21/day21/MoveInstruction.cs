
namespace day21
{
    public class MoveInstruction : Instruction
    {
        private readonly int _origin;
        private readonly int _destination;

        public MoveInstruction(int origin, int destination)
        {
            _origin = origin;
            _destination = destination;
        }

        // move position X to position Y means that the letter which is at index X should 
        // be removed from the string, then inserted such that it ends up at index Y.
        public override string Mutate(string password)
        {
            var charToMove = password[_origin].ToString();
            return password.Remove(_origin, 1).Insert(_destination, charToMove);
        }
    }
}