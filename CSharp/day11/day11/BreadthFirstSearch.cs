using System;
using System.Collections.Generic;

namespace day11
{
    class BreadthFirstSearch
    {
        public static int GetFewestMovesToGoal(Building startState, string goalState)
        {
            var numberOfMoves = 0;
            var found = false;
            var visitedStates = new HashSet<string>();
            var queue = new Queue<Building>();
            queue.Enqueue(startState);
            visitedStates.Add(startState.ToString());

            while (queue.Count != 0)
            {
                var nextQueue = new Queue<Building>();
                while (queue.Count > 0)
                {
                    var currentState = queue.Dequeue();
                    //Console.WriteLine(currentState);
                    if (currentState.ToString() == goalState)
                    {
                        found = true;
                        break;
                    }

                    foreach (var nextState in currentState.GetPossibleNextStates())
                    {
                        var nextStateHash = nextState.ToString();
                        if (!visitedStates.Contains(nextStateHash))
                        {
                            nextQueue.Enqueue(nextState);
                            visitedStates.Add(nextStateHash);
                        }
                    }
                }

                if (found)
                    break;

                //Console.WriteLine($"========================   {numberOfMoves}   ========================");
                numberOfMoves++;
                queue = nextQueue;
            }
            return numberOfMoves;
        }
    }
}