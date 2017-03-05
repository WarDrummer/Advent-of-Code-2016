using System;

namespace day8
{
    public class RotateRowInstruction : Instruction
    {
        private readonly int _rowIndex;
        private readonly int _rotation;

        public RotateRowInstruction(int rowIndex, int rotation)
        {
            _rowIndex = rowIndex;
            _rotation = rotation;
        }

        public override void Execute(LittleScreen screen)
        {
            var length = screen.Pixels[0].Length;
            var current = new bool[length];
            for (var x = 0; x < length; x++)
            {
                current[x] = screen.Pixels[_rowIndex][x];
            }

            for (var x = 0; x < length; x++)
            {
                var newX = (x + _rotation) % length;
                screen.Pixels[_rowIndex][newX] = current[x];
            }
        }

        public static Instruction Parse(string command)
        {
            var parts = command.Split(' ');
            var rowIndex = int.Parse(parts[2].Split('=')[1]);
            var rotation = int.Parse(parts[4]);
            return new RotateRowInstruction(rowIndex, rotation);
        }
    }
}