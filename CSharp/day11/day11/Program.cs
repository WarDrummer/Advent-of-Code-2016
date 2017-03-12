using System;
using System.Collections.Generic;

namespace day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbols = new[] {'H', 'L'};

            var goalState = new Building(
                new[]
                {
                    new Floor( // 1
                        symbols,
                        new [] {false, false},
                        new [] {false, false}),
                    new Floor( // 2
                        symbols,
                        new [] {false, false},
                        new [] {false, false}),
                    new Floor( // 3
                        symbols,
                        new [] {false, false},
                        new [] {false, false}),
                    new Floor( // 4
                        symbols,
                        new [] {true, true},
                        new [] {true, true}),
                },
                3).ToString();

            var building = new Building(
                new []
                {
                    new Floor( // 1
                        symbols, 
                        new [] {true, true}, 
                        new [] {false, false}),
                    new Floor( // 2
                        symbols,
                        new [] {false, false},
                        new [] {true, false}),
                    new Floor( // 3
                        symbols,
                        new [] {false, false},
                        new [] {false, true}),
                    new Floor( // 4
                        symbols,
                        new [] {false, false},
                        new [] {false, false}),
                },
                0);

            var i = 0;
            building.MarkAsPreviouslyRead();

            var queue = new Queue<Building>();
            queue.Enqueue(building);

            while (queue.Count != 0)
            {
                var newQueue = new Queue<Building>();
                while (queue.Count > 0)
                {
                    var currentBuilding = queue.Dequeue();
                    Console.WriteLine(currentBuilding);
                    if (currentBuilding.ToString() == goalState)
                    {
                        newQueue.Clear();
                        break;
                    }

                    foreach (var newB in currentBuilding.GetValidNextStates())
                    {
                        newQueue.Enqueue(newB);
                    }
                }
                Console.WriteLine($"========================   {i}   ========================");
                i++;
                queue = newQueue;
            }
 
            Console.WriteLine(i);
            Console.ReadKey();
        }
    }
}
