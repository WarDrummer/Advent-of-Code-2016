using System.Text;

namespace day8
{
    public class LittleScreen
    {
        public readonly bool[][] Pixels;

        public LittleScreen(int width = 50, int height = 6)
        {
            Pixels = new bool[height][];
            for (var i = 0; i < Pixels.Length; i++)
            {
                Pixels[i] = new bool[width];
            }
        }

        public int GetNumberOfLitPixels()
        {
            var count = 0;
            foreach (var row in Pixels)
            {
                foreach (var pixel in row)
                {
                    if (pixel)
                        count++;
                }
            }
            return count;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var row in Pixels)
            {
                foreach (var pixel in row)
                {
                    sb.Append(pixel ? '#' : '.');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}