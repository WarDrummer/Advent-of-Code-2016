using System;
using System.Collections.Generic;

namespace Tools
{
    public interface INode : IComparable<INode>
    {
        IEnumerable<INode> GetNextNodes();
        string UniqueIdentifier { get; }
    }

    public class BreadthFirstSearch
    {
        private readonly INode _goal;

        public BreadthFirstSearch(INode goal)
        {
            _goal = goal;
        }

        public int GetMinimumNumberOfMoves(INode start)
        {
            var matchFound = false;
            var numberOfMoves = 0;

            var currentNodes = new Queue<INode>();
            currentNodes.Enqueue(start);

            var nextNodes = new Queue<INode>();
            var visited = new HashSet<string>();

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
                    nextNodes = new Queue<INode>();
                    numberOfMoves += 1;
                }
            }

            return matchFound ? numberOfMoves : -1;
        }
    }
}
