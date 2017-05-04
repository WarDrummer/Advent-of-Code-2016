using System.Collections.Generic;
using System.IO;

namespace Tools
{
    public class LineByLine
    {
        public static IEnumerable<string> GetLines(string filename)
        {
            using (var file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
