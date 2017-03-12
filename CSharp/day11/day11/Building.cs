using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day11
{
    public class Building
    {
        private static readonly HashSet<string> PreviouslyGeneratedBuildings = new HashSet<string>();

        private readonly Floor[] _floors;
        private int _elevatorFloorIndex;

        public void MarkAsPreviouslyRead()
        {
            PreviouslyGeneratedBuildings.Add(this.ToString());
        }

        public Building(IReadOnlyCollection<char> symbols)
        {
            _floors = new[]
            {
                new Floor(symbols, new char[0], new char[0]),
                new Floor(symbols, new char[0], new char[0]),
                new Floor(symbols, new char[0], new char[0]),
                new Floor(symbols, new char[0], new char[0])
            };
        }

        public Building(Floor[] floors, int elevatorFloorIndex)
        {
            _floors = floors;
            _elevatorFloorIndex = elevatorFloorIndex;
        }

        public IEnumerable<Building> GetValidNextStates()
        {
            var possibleComponentsToMove = _floors[_elevatorFloorIndex].GetPossibleMoveCombinations().ToArray();
            foreach (var combinations in possibleComponentsToMove)
            {
                var currentFloor = _floors[_elevatorFloorIndex].GetFloorWithout(combinations);
                if(!currentFloor.IsValid())
                    continue;

                if (_elevatorFloorIndex < 3) // move up
                {
                    var floorAbove =  _floors[_elevatorFloorIndex + 1].GetFloorWith(combinations);
                    if (floorAbove.IsValid())
                    {
                        var newBuilding = Clone();
                        newBuilding._floors[_elevatorFloorIndex + 1] = floorAbove;
                        newBuilding._floors[_elevatorFloorIndex] = currentFloor;
                        newBuilding._elevatorFloorIndex = _elevatorFloorIndex + 1;

                        var hash = newBuilding.ToString();
                        if (!PreviouslyGeneratedBuildings.Contains(hash))
                        {
                            PreviouslyGeneratedBuildings.Add(hash);
                            yield return newBuilding;
                        }
                    }
                }

                if (_elevatorFloorIndex > 0) // move down
                {
                    var floorBelow = _floors[_elevatorFloorIndex - 1].GetFloorWith(combinations);
                    if (floorBelow.IsValid())
                    {
                        var newBuilding = Clone();
                        newBuilding._floors[_elevatorFloorIndex - 1] = floorBelow;
                        newBuilding._floors[_elevatorFloorIndex] = currentFloor;
                        newBuilding._elevatorFloorIndex = _elevatorFloorIndex - 1;

                        var hash = newBuilding.ToString();
                        if (!PreviouslyGeneratedBuildings.Contains(hash))
                        {
                            PreviouslyGeneratedBuildings.Add(hash);
                            yield return newBuilding;
                        }
                    }
                }
            }
        }

        private Building Clone()
        {
            return new Building(
                new Floor[4]
                {
                    _floors[0].Clone(),
                    _floors[1].Clone(),
                    _floors[2].Clone(),
                    _floors[3].Clone()
                },
                _elevatorFloorIndex);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var floorIndex = 3; floorIndex >= 0; floorIndex--)
            {
                sb.Append($"F{floorIndex+1} ");
                sb.Append((floorIndex == _elevatorFloorIndex) ? "E  " : ".  ");
                sb.Append(_floors[floorIndex]);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}