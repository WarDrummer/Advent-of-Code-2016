using System;
using Tools;

namespace day11
{
    class Program
    {
        static void Main(string[] args)
        {
            // PART 1
            /**/
            var symbols = new[] { 'S', 'P', 'C', 'R', 'T' };

            var startState = new Building(symbols);

            //The first floor contains a strontium generator, a strontium-compatible microchip, a plutonium generator, and a plutonium - compatible microchip
            startState.SetGeneratorLocation(0, 'S');
            startState.SetMicrochipLocation(0, 'S');
            startState.SetGeneratorLocation(0, 'P');
            startState.SetMicrochipLocation(0, 'P');

            //The second floor contains a thulium generator, a ruthenium generator, a ruthenium-compatible microchip, a curium generator, and a curium - compatible microchip.
            startState.SetGeneratorLocation(1, 'T');
            startState.SetGeneratorLocation(1, 'R');
            startState.SetMicrochipLocation(1, 'R');
            startState.SetGeneratorLocation(1, 'C');
            startState.SetMicrochipLocation(1, 'C');

            //The third floor contains a thulium-compatible microchip.
            startState.SetMicrochipLocation(2, 'T');
            //*/

            // PART 2
            /** /
            var symbols = new[] { 'S', 'P', 'C', 'R', 'T', 'E', 'D' };

            var startState = new Building(symbols);

            //The first floor contains a strontium generator, a strontium-compatible microchip, a plutonium generator, and a plutonium - compatible microchip
            startState.SetGeneratorLocation(0, 'S');
            startState.SetMicrochipLocation(0, 'S');
            startState.SetGeneratorLocation(0, 'P');
            startState.SetMicrochipLocation(0, 'P');

            // first floor part 2
            startState.SetGeneratorLocation(0, 'E');
            startState.SetMicrochipLocation(0, 'E');
            startState.SetGeneratorLocation(0, 'D');
            startState.SetMicrochipLocation(0, 'D');

            //The second floor contains a thulium generator, a ruthenium generator, a ruthenium-compatible microchip, a curium generator, and a curium - compatible microchip.
            startState.SetGeneratorLocation(1, 'T');
            startState.SetGeneratorLocation(1, 'R');
            startState.SetMicrochipLocation(1, 'R');
            startState.SetGeneratorLocation(1, 'C');
            startState.SetMicrochipLocation(1, 'C');

            //The third floor contains a thulium-compatible microchip.
            startState.SetMicrochipLocation(2, 'T');
            //*/

            /** /
            var symbols = new[] { 'H', 'L' };

            var startState = new Building(symbols);

            startState.SetGeneratorLocation(2, 'L');
            startState.SetGeneratorLocation(1, 'H');
            startState.SetMicrochipLocation(0, 'H');
            startState.SetMicrochipLocation(0, 'L');
            //*/

            var bfs = new BreadthFirstSearch<long>(Building.CreateGoalState(symbols));
            var fewestMoves = bfs.GetMinimumNumberOfMoves(startState);
           
            Console.WriteLine(fewestMoves);
            Console.ReadKey();
        }
    }
}
