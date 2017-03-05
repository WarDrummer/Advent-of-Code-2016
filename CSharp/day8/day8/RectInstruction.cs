using System;
using System.Runtime.InteropServices;

namespace day8
{
    public class RectInstruction : Instruction
    {
        private readonly int _width;
        private readonly int _height;

        private RectInstruction(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public static Instruction Parse(string command)
        {
            var parts = command.Split(' ')[1].Split('x');
            var width = int.Parse(parts[0]);
            var height = int.Parse(parts[1]);
            return new RectInstruction(width, height);
        }

        public override void Execute(LittleScreen screen)
        {
            for (var x = 0; x < _width; x++)
            {
                for (var y = 0; y < _height; y++)
                {
                    screen.Pixels[y][x] = true;
                }
            }
        }
    }
}