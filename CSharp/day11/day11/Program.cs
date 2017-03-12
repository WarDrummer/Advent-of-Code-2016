using System;
using System.Collections.Generic;

namespace day11
{
    class Program
    {
        static void Main(string[] args)
        {
            /** /
             * var symbols = new[] { 'S', 'P', 'C', 'R', 'T' };

            var startState = new Building(symbols);

            //The first floor contains a strontium generator, a strontium-compatible microchip, a plutonium generator, and a plutonium - compatible microchip
            startState.AddGenerator(0, 'S');
            startState.AddMicrochip(0, 'S');
            startState.AddGenerator(0, 'P');
            startState.AddMicrochip(0, 'P');

            //The second floor contains a thulium generator, a ruthenium generator, a ruthenium-compatible microchip, a curium generator, and a curium - compatible microchip.
            startState.AddGenerator(1, 'T');
            startState.AddGenerator(1, 'R');
            startState.AddMicrochip(1, 'R');
            startState.AddGenerator(1, 'C');
            startState.AddMicrochip(1, 'C');

            //The third floor contains a thulium-compatible microchip.
            startState.AddMicrochip(2, 'T');
            //*/


            /**/
            var symbols = new[] { 'H', 'L' };

            var startState = new Building(symbols);

            startState.AddGenerator(2, 'L');
            startState.AddGenerator(1, 'H');
            startState.AddMicrochip(0, 'H');
            startState.AddMicrochip(0, 'L');

            var fewestMoves = BreadthFirstSearch.GetFewestMovesToGoal(
                startState, 
                Building.CreateGoalState(symbols).ToString());
            //*/

            // 49 is too high :-/
            Console.WriteLine(fewestMoves);
            Console.ReadKey();
        }
    }
}
