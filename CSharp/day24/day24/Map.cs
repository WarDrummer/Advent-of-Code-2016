using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day24
{
    public class Map
    {
        private readonly string[] _lines;
        private char[][] _charMap = {};
        private Dictionary<int, Location> _pointsOfInterest = new Dictionary<int, Location>();
        private Dictionary<int, Dictionary<int, int>> _costGraph = new Dictionary<int, Dictionary<int, int>>();
        
        public Map(string[] lines)
        {
            _lines = lines;
        }

        public void Initialize()
        {
            BuildCharMap();
            FindPointsOfInterest();
            BuildCostGraph();
        }

        private void BuildCostGraph()
        {
            _costGraph = new Dictionary<int, Dictionary<int, int>>();
            var locations = _pointsOfInterest.Keys.ToArray();
            for (var i = 0; i < locations.Length; i++)
            {
                var keyLocationA = locations[i];
                var locationA = _pointsOfInterest[keyLocationA];
                for (var j = i + 1; j < locations.Length; j++)
                {
                    var keyLocationB = locations[j];
                    var locationB = _pointsOfInterest[keyLocationB];
                    var cost = FindDistanceFrom(locationA, locationB);

                    if (!_costGraph.ContainsKey(keyLocationA))
                        _costGraph[keyLocationA] = new Dictionary<int, int>();

                    _costGraph[keyLocationA].Add(keyLocationB, cost);

                    if (!_costGraph.ContainsKey(keyLocationB))
                        _costGraph[keyLocationB] = new Dictionary<int, int>();

                    _costGraph[keyLocationB].Add(keyLocationA, cost);
                }
            }
        }

        private int FindDistanceFrom(Location a, Location b)
        {
            //Console.WriteLine($"Finding distance from {a.X}, {a.Y} => {b.X}, {b.Y}");
            var distance = 0;
            var seen = new HashSet<long> { a.UniqueIdentifier };

            var q = new Queue<Location>();
            q.Enqueue(a);

            var nextQ = new Queue<Location>();

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                //Console.WriteLine($"Trying {current.X}, {current.Y}");
                if (current.IsEqualTo(b))
                    return distance;

                foreach (var adjacentLocation in GetPassableAdjacentLocations(current))
                {
                    if (seen.Contains(adjacentLocation.UniqueIdentifier))
                        continue;

                    seen.Add(adjacentLocation.UniqueIdentifier);
                    nextQ.Enqueue(adjacentLocation);
                }

                if (q.Count == 0)
                {
                    //Console.WriteLine("Increasing breadth");
                    q = nextQ;
                    nextQ = new Queue<Location>();
                    distance += 1;
                }
            }

            return -1;
        }

        private IEnumerable<Location> GetPassableAdjacentLocations(Location location)
        {
            var up = new Location(location.X, location.Y - 1);
            if (IsLocationPassable(up))
                yield return up;

            var down = new Location(location.X, location.Y + 1);
            if (IsLocationPassable(down))
                yield return down;

            var left = new Location(location.X - 1, location.Y);
            if (IsLocationPassable(left))
                yield return left;

            var right = new Location(location.X + 1, location.Y);
            if (IsLocationPassable(right))
                yield return right;
        }

        private bool IsLocationPassable(Location location)
        {
            var x = location.X;
            var y = location.Y;

            if (x < 0 || y < 0 || x >= _charMap[0].Length || y >= _charMap.Length)
            {
                return false;
            }

            var c = _charMap[y][x];
            return c == '.' || char.IsNumber(c);
        }

        private void FindPointsOfInterest()
        {
            _pointsOfInterest = new Dictionary<int, Location>();
            for (var y = 0; y < _charMap.Length; y++)
            {
                var row = _charMap[y];
                for (var x = 0; x < row.Length; x++)
                {
                    var c = row[x];
                    if (char.IsNumber(c))
                    {
                        _pointsOfInterest[c] = new Location(x, y);
                    }
                }
            }
        }

        private void BuildCharMap()
        {
            _charMap = new char[_lines.Length][];
            var mapIndex = 0;
            foreach (var line in _lines)
            {
                _charMap[mapIndex++] = line.ToCharArray();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("============= MAP =============");
            foreach (var row in _charMap)
            {
                foreach (var c in row)
                {
                    sb.Append(c);
                }
                sb.AppendLine();
            }

            sb.AppendLine("============= LOCATIONS =============");
            foreach (var kvp in _pointsOfInterest)
            {
                sb.AppendLine($"{(char)kvp.Key} -> ({kvp.Value.X}, {kvp.Value.Y})");
            }

            sb.AppendLine("============= COSTS =============");
            foreach (var kvp in _costGraph)
            {
                foreach (var cost in kvp.Value)
                {
                    sb.AppendLine($"{(char)kvp.Key} => {(char)cost.Key} = {cost.Value}");
                }
            }

            return sb.ToString();
        }
    }
}