using System;
using System.Collections.Generic;

namespace day13
{
    public class ShortestPathFinder
    {
        private readonly Coordinate _start;
        private readonly Coordinate _goal;

        public ShortestPathFinder(Coordinate start, Coordinate goal)
        {
            _start = start;
            _goal = goal;
        }

        public Tuple<int, int> GetFewestNumberOfSteps(int favoriteNumber, int maxDepth = int.MaxValue)
        {
            Location.FavoriteNumber = favoriteNumber;

            var done = false;
            var considered = new HashSet<string>();
            var passable = new HashSet<string>();
            var queue = new Queue<Coordinate>();
            queue.Enqueue(_start);
            considered.Add(_start.ToString());
            passable.Add(_start.ToString());

            var moveCount = 0;
            while (queue.Count > 0 && moveCount < maxDepth)
            {
                var nextQueue = new Queue<Coordinate>();

                while (queue.Count > 0)
                {
                    var currentCoordinate = queue.Dequeue();
                    if (currentCoordinate.X == _goal.X && currentCoordinate.Y == _goal.Y)
                    {
                        done = true;
                        break;
                    }

                    foreach (var coord in currentCoordinate.GetValidAdjacentCoordinates())
                    {
                        var hash = coord.ToString();
                        if (!considered.Contains(hash))
                        {
                            considered.Add(hash);
                            if (Location.Create(coord.X, coord.Y).IsPassable)
                            {
                                passable.Add(hash);
                                nextQueue.Enqueue(coord);
                            }
                        }
                    }
                }

                if (done)
                    break;

                queue = nextQueue;
                moveCount++;
            }
            
            return new Tuple<int, int>(moveCount, passable.Count);
        }
    }
}