using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;
            using (var fs = File.Open("input.txt", FileMode.Open))
            {
                var reader = new StreamReader(fs);
                var line = reader.ReadLine();
                while (line != null)
                {
                    var room = new Room(line);
                    if (room.IsValid())
                    {
                        count += room.SectorID;
                        if (room.DecodedName.Contains("northpole object storage"))
                        {
                            Console.WriteLine($"{room.DecodedName} - {room.SectorID}");
                        }
                    }
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine(count);
            Console.Read();
        }
    }
}
