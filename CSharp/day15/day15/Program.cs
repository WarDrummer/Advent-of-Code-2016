using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace day15
{
    class Program
    {
        static void Main(string[] args)
        {
            var discsExample = new Discs(new []
            {
                new Disc(4 + 1, 5),
                new Disc(1 + 2, 2)
            });
            Console.WriteLine(discsExample.GetFirstTime());


            //Disc #1 has 17 positions; at time=0, it is at position 15.
            //Disc #2 has 3 positions; at time=0, it is at position 2.
            //Disc #3 has 19 positions; at time=0, it is at position 4.
            //Disc #4 has 13 positions; at time=0, it is at position 2.
            //Disc #5 has 7 positions; at time=0, it is at position 2.
            //Disc #6 has 5 positions; at time=0, it is at position 0.
            var discsPart1 = new Discs(new[]
            {
                new Disc(15 + 1, 17),
                new Disc(2 + 2, 3),
                new Disc(4 + 3, 19),
                new Disc(2 + 4, 13),
                new Disc(2 + 5, 7),
                new Disc(0 + 6, 5)
            });
            Console.WriteLine(discsPart1.GetFirstTime());

            var discsPart2 = new Discs(new[]
            {
                new Disc(15 + 1, 17),
                new Disc(2 + 2, 3),
                new Disc(4 + 3, 19),
                new Disc(2 + 4, 13),
                new Disc(2 + 5, 7),
                new Disc(0 + 6, 5),
                new Disc(0 + 7, 11)
            });
            Console.WriteLine(discsPart2.GetFirstTime());


            Console.ReadKey();
        }
    }

    class Discs
    {
        private readonly Disc[] _discs;

        public Discs(Disc[] discs)
        {
            _discs = discs;
        }

        public int GetFirstTime()
        {
            var time = 0;

            while (!AllDiscsOpen())
            {
                AdvanceAll();
                time++;
            }

            return time;
        }

        private bool AllDiscsOpen()
        {
            return _discs.All(d => d.IsOpen());
        }

        private void AdvanceAll()
        {
            foreach (var d in _discs)
            {
                d.Advance();
            }
        }
    }
    class Disc
    {
        private int _currentPosition;
        private readonly int _numberOfPositions;

        public Disc(int startingPosition, int numberOfPositions)
        {
            _currentPosition = startingPosition % numberOfPositions;
            _numberOfPositions = numberOfPositions;
        }

        public void Advance()
        {
            _currentPosition = (_currentPosition + 1) % _numberOfPositions;
        }

        public bool IsOpen()
        {
            return _currentPosition == 0;
        }
    }
}
