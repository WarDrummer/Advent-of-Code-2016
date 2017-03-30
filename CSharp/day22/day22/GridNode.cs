using System;
using System.Collections;
using System.Collections.Generic;

namespace day22
{
    public class GridNode
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Used { get; private set; }
        public int Available { get; private set; }

        public static GridNode Create(string nodeInfo)
        {
            //Filesystem              Size  Used  Avail  Use%
            // /dev/grid/node-x0-y0     93T   67T    26T   72%
            var parts = nodeInfo.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var fileSystem = parts[0].Split('-');

            return new GridNode()
            {
                X = int.Parse(fileSystem[1].Substring(1, fileSystem[1].Length - 1)),
                Y = int.Parse(fileSystem[2].Substring(1, fileSystem[2].Length - 1)),
                Used = int.Parse(parts[2].Remove(parts[2].Length - 1)),
                Available = int.Parse(parts[3].Remove(parts[3].Length - 1)),
            };
        }

        public IEnumerable<GridNode> ValidAdjacentNodes(GridNode[][] nodes)
        {

            return null;
        }

        public int UniqueIdentifier()
        {
            return X + (Y << 16);
        }

        public bool MakesViablePair(GridNode b)
        {
            var a = this;
            //    Node A is not empty(its Used is not zero).
            //    Nodes A and B are not the same node.
            //    The data on node A(its Used) would fit on node B(its Avail).
            return a.Used != 0 && a.UniqueIdentifier() != b.UniqueIdentifier() && b.Available >= a.Used;
        }
    }
}