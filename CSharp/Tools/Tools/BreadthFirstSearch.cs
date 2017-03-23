using System;
using System.Collections.Generic;

namespace Tools
{
    public interface INode<T> : IComparable<INode<T>>
    {
        IEnumerable<INode<T>> GetNextNodes();
        T UniqueIdentifier { get; }
    }

    public class BreadthFirstSearch<T>
    {
        private readonly INode<T> _goal;

        public BreadthFirstSearch(INode<T> goal)
        {
            _goal = goal;
        }

        public int GetMinimumNumberOfMoves(INode<T> start)
        {
            var matchFound = false;
            var numberOfMoves = 0;

            var currentNodes = new Queue<INode<T>>();
            currentNodes.Enqueue(start);

            var nextNodes = new Queue<INode<T>>();
            var visited = new HashSet<T>();

            while (currentNodes.Count > 0)
            {
                var currentNode = currentNodes.Dequeue();

                if (currentNode.CompareTo(_goal)== 0)
                {
                    matchFound = true;
                    break;
                }

                foreach (var nextNode in currentNode.GetNextNodes())
                {
                    if (!visited.Contains(nextNode.UniqueIdentifier))
                    {
                        nextNodes.Enqueue(nextNode);
                        visited.Add(nextNode.UniqueIdentifier);
                    }
                }

                if (currentNodes.Count == 0)
                {
                    currentNodes = nextNodes;
                    nextNodes = new Queue<INode<T>>();
                    numberOfMoves += 1;
                }
            }

            return matchFound ? numberOfMoves : -1;
        }
    }
}
