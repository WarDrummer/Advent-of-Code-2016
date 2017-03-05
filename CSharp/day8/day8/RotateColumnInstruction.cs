using System;

namespace day8
{
    public class RotateColumnInstruction : Instruction
    {
        private readonly int _columnIndex;
        private readonly int _rotation;

        private RotateColumnInstruction(int columnIndex, int rotation)
        {
            _columnIndex = columnIndex;
            _rotation = rotation;
        }

        public override void Execute(LittleScreen screen)
        {
            var current = new bool[screen.Pixels.Length];
            for (var y = 0; y < screen.Pixels.Length; y++)
            {
                current[y] = screen.Pixels[y][_columnIndex];
            }

            for (var y = 0; y < screen.Pixels.Length; y++)
            {
                var newY = (y + _rotation) % screen.Pixels.Length;
                screen.Pixels[newY][_columnIndex] = current[y];
            }
        }

        public static Instruction Parse(string command)
        {
            var parts = command.Split(' ');
            var columnIndex = int.Parse(parts[2].Split('=')[1]);
            var rotation = int.Parse(parts[4]);
            return new RotateColumnInstruction(columnIndex, rotation);
        }
    }
}