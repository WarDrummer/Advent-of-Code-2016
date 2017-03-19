using System;

namespace day11
{
    class Program
    {
        static void Main(string[] args)
        {
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


            /** /
            var symbols = new[] { 'H', 'L' };

            var startState = new Building(symbols);

            startState.SetGeneratorLocation(2, 'L');
            startState.SetGeneratorLocation(1, 'H');
            startState.SetMicrochipLocation(0, 'H');
            startState.SetMicrochipLocation(0, 'L');
            //*/

            var fewestMoves = BreadthFirstSearch.GetFewestMovesToGoal(
                startState, 
                Building.CreateGoalState(symbols).ToString());
           

            // 48 is too high :-/
            Console.WriteLine(fewestMoves);
            Console.ReadKey();
        }
    }
}
