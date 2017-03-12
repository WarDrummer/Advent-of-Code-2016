using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day11
{

    public class Building
    {
        private readonly IList<char> _symbols;
        private readonly bool[][] _floors = new bool[4][];
        private int _elevatorLocation;
        private const string Missing = ".  ";

        public static Building CreateGoalState(char[] symbols)
        {
            var goalStateBuilding = new Building(symbols);
            goalStateBuilding.SetElevatorFloor(3);
            foreach (var symbol in symbols)
            {
                goalStateBuilding.AddGenerator(3, symbol);
                goalStateBuilding.AddMicrochip(3, symbol);
            }
            return goalStateBuilding;
        }

        public Building(IReadOnlyCollection<char> symbols)
        {
            _symbols = new List<char>(symbols);
            for (var i = 0; i < 4; i++)
            {
                _floors[i] = new bool[symbols.Count*2];
            }
        }

        private Building(IEnumerable<char> symbols, bool[][] floors)
        {
            _symbols = new List<char>(symbols);
            _floors = floors;
        }

        public void AddMicrochip(int floor, char element)
        {
            _floors[floor][_symbols.IndexOf(element)] = true;
        }

        public void AddGenerator(int floor, char element)
        {
            _floors[floor][_symbols.IndexOf(element) + _symbols.Count] = true;
        }

        public void SetElevatorFloor(int floorIndex)
        {
            _elevatorLocation = floorIndex;
        }

        public bool IsValid()
        {
            for (var floorIndex = 0; floorIndex < 4; floorIndex++)
            {
                if (!IsFloorValid(floorIndex))
                    return false;
            }
            return true;
        }

        private bool IsFloorValid(int floor)
        {
            for (var i = 0; i < _symbols.Count; i++)
            {
                var microchipExists = _floors[floor][i];
                var matchingGeneratorExists = _floors[floor][i + _symbols.Count];
                if (microchipExists && !matchingGeneratorExists && AreGeneratorsPresent(floor))
                    return false;
            }
            return true;
        }

        private bool AreGeneratorsPresent(int floor)
        {
            for (var generatorIndex = _symbols.Count; generatorIndex < _symbols.Count*2; generatorIndex++)
            {
                if (_floors[floor][generatorIndex])
                    return true;
            }
            return false;
        }

        public IEnumerable<Building> GetPossibleNextStates()
        {
            var microchips = GetMicrochipsOnCurrentFloor();
            var generators = GetGeneratorsOnCurrentFloor();
            var none = new char[0];

            if (_elevatorLocation > 0) // can move down
            {
                foreach (var microchip in microchips)
                {
                    var building = MoveDown(new[] {microchip}, none);
                    if (building.IsValid())
                    {
                        yield return building;
                    }

                    foreach (var microchip2 in microchips)
                    {
                        if (microchip != microchip2)
                        {
                            building = MoveDown(new[] {microchip, microchip2}, none);
                            if (building.IsValid())
                            {
                                yield return building;
                            }
                        }
                    }

                    foreach (var generator in generators)
                    {
                        building = MoveDown(new[] { microchip }, new []{ generator });
                        if (building.IsValid())
                        {
                            yield return building;
                        }   
                    }
                }

                foreach (var generator in generators)
                {
                    foreach (var generator2 in generators)
                    {
                        if (generator != generator2)
                        {
                            var building = MoveDown(none, new[] {generator, generator2});
                            if (building.IsValid())
                            {
                                yield return building;
                            }
                        }
                    }
                }
            }

            if (_elevatorLocation < 3) // can move up
            {
                foreach (var microchip in microchips)
                {
                    var building = MoveUp(new[] { microchip }, none);
                    if (building.IsValid())
                    {
                        yield return building;
                    }

                    foreach (var microchip2 in microchips)
                    {
                        if (microchip != microchip2)
                        {
                            building = MoveUp(new[] { microchip, microchip2 }, none);
                            if (building.IsValid())
                            {
                                yield return building;
                            }
                        }
                    }

                    foreach (var generator in generators)
                    {
                        building = MoveUp(new[] { microchip }, new[] { generator });
                        if (building.IsValid())
                        {
                            yield return building;
                        }    
                    }
                }

                foreach (var generator in generators)
                {
                    foreach (var generator2 in generators)
                    {
                        if (generator != generator2)
                        {
                            var building = MoveUp(none, new[] { generator, generator2 });
                            if (building.IsValid())
                            {
                                yield return building;
                            }
                        }
                    }
                }
            }
        }

        private char[] GetMicrochipsOnCurrentFloor()
        {
            var microchips = new List<char>();
            for (var i = 0; i < _symbols.Count; i++)
            {
                if (_floors[_elevatorLocation][i])
                {
                    microchips.Add(_symbols[i]);
                }
            }
            return microchips.ToArray();
        }

        private char[] GetGeneratorsOnCurrentFloor()
        {
            var generators = new List<char>();
            for (var i = 0; i < _symbols.Count; i++)
            {
                if (_floors[_elevatorLocation][i + _symbols.Count])
                {
                    generators.Add(_symbols[i]);
                }
            }
            return generators.ToArray();
        }

        private Building MoveUp(char[] microchips, char[] generators)
        {
            var floors = CloneFloors();
            foreach (var microchip in microchips)
            {
                var index = _symbols.IndexOf(microchip);
                floors[_elevatorLocation][index] = false;
                floors[_elevatorLocation + 1][index] = true;
            }

            foreach (var generator in generators)
            {
                var index = _symbols.IndexOf(generator) + _symbols.Count;
                floors[_elevatorLocation][index] = false;
                floors[_elevatorLocation + 1][index] = true;
            }

            return new Building(_symbols, floors)
            {
                _elevatorLocation = _elevatorLocation + 1
            };
        }

        private Building MoveDown(char[] microchips, char[] generators)
        {
            var floors = CloneFloors();
            foreach (var microchip in microchips)
            {
                var index = _symbols.IndexOf(microchip);
                floors[_elevatorLocation][index] = false;
                floors[_elevatorLocation - 1][index] = true;
            }

            foreach (var generator in generators)
            {
                var index = _symbols.IndexOf(generator) + _symbols.Count;
                floors[_elevatorLocation][index] = false;
                floors[_elevatorLocation - 1][index] = true;
            }

            return new Building(_symbols, floors)
            {
                _elevatorLocation = _elevatorLocation - 1
            };
        }

        private bool[][] CloneFloors()
        {
            return _floors.Select(a => a.ToArray()).ToArray();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var floorIndex = 3; floorIndex >= 0; floorIndex--)
            {
                sb.Append($"F{floorIndex + 1} ");
                sb.Append((_elevatorLocation == floorIndex) ? "E  " : Missing);

                for (var microchipIndex = 0; microchipIndex < _symbols.Count; microchipIndex++)
                {
                    var generatorIndex = _symbols.Count + microchipIndex;
                    sb.Append(_floors[floorIndex][microchipIndex] ? AsMicrochip(_symbols[microchipIndex]) : Missing);
                    sb.Append(_floors[floorIndex][generatorIndex] ? AsGenerator(_symbols[microchipIndex]) : Missing);
                }

                sb.AppendLine();
            }
            return sb.ToString();
        }

        private static string AsMicrochip(char element)
        {
            return $"{element}M ";
        }

        private static string AsGenerator(char element)
        {
            return $"{element}G ";
        }
    }

}