using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Tools;

namespace day11
{
    using Node = INode<long>;
    public class Building : Node
    {
        private readonly IList<char> _symbols;
        private readonly int[] _generatorLocations;
        private readonly int[] _microchipLocations;
        public int ElevatorLocation { get; set; }
        private const string Missing = ".  ";

        public static Building CreateGoalState(char[] symbols)
        {
            var goalStateBuilding = new Building(symbols) {ElevatorLocation = 3};
            foreach (var symbol in symbols)
            {
                goalStateBuilding.SetGeneratorLocation(3, symbol);
                goalStateBuilding.SetMicrochipLocation(3, symbol);
            }
            return goalStateBuilding;
        }

        public Building(IEnumerable<char> symbols)
        {
            _symbols = new List<char>(symbols);
            _generatorLocations = new int[_symbols.Count];
            _microchipLocations = new int[_symbols.Count];
        }

        private Building(IEnumerable<char> symbols, int[] microchipLocations, int[] generatorLocations)
        {
            _symbols = new List<char>(symbols);
            _microchipLocations = microchipLocations;
            _generatorLocations = generatorLocations;
        }

        public void SetMicrochipLocation(int floor, char element)
        {
            _microchipLocations[_symbols.IndexOf(element)] = floor;
        }

        public int GetMicrochipLocation(char element)
        {
            return _microchipLocations[_symbols.IndexOf(element)];
        }

        public void SetGeneratorLocation(int floor, char element)
        {
            _generatorLocations[_symbols.IndexOf(element)] = floor;
        }

        public int GetGeneratorLocation(char element)
        {
            return _generatorLocations[_symbols.IndexOf(element)];
        }

        public bool IsValid()
        {
            for (var floorIndex = 0; floorIndex < 4; floorIndex++)
            {
                if (!IsFloorValid(floorIndex))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsFloorValid(int floorIndex)
        {
            if (_microchipLocations.Contains(floorIndex))
            {
                for (var i = 0; i < _microchipLocations.Length; i++)
                {
                    // if microchip is on floor and doesn't have its corresponding generator
                    if (_microchipLocations[i] == floorIndex && _generatorLocations[i] != floorIndex)
                    {
                        // if a non-corresponding generator is on the floor, we burned up a chip
                        if (_generatorLocations.Any(gl => gl == floorIndex))
                            return false;
                    }
                }
            }

            return true;
        }

        public delegate Building MoveItems(IEnumerable<char> microchips, IEnumerable<char> generators);

        public IEnumerable<Building> GetPossibleNextStates()
        {
            var microchips = GetMicrochipsOnCurrentFloor();
            var generators = GetGeneratorsOnCurrentFloor();

            if (ElevatorLocation > 0)
            {
                foreach (var building in CreateNewState(microchips, generators, MoveDown))
                    yield return building;
            }

            if (ElevatorLocation < 3)
            {
                foreach (var building in CreateNewState(microchips, generators, MoveUp))
                    yield return building;
            }
        }

        private static IEnumerable<Building> CreateNewState(char[] microchips, char[] generators, MoveItems moveItems)
        {
            var none = new char[0];

            for (var i = 0; i < microchips.Length; i++)
            {
                var microchip = microchips[i];
                var building = moveItems(new[] {microchip}, none);
                if (building.IsValid())
                    yield return building;

                for (var j = i + 1; j < microchips.Length; j++)
                {
                    var otherMicrochip = microchips[j];
                    if (microchip == otherMicrochip)
                        continue;

                    building = moveItems(new[] {microchip, otherMicrochip}, none);
                    if (building.IsValid())
                        yield return building;
                }

                foreach (var generator in generators)
                {
                    building = moveItems(new[] {microchip}, new[] {generator});
                    if (building.IsValid())
                        yield return building;
                }
            }

            for (var i = 0; i < generators.Length; i++)
            {
                var generator = generators[i];
                var building = moveItems(none, new[] {generator});
                if (building.IsValid())
                    yield return building;

                for (var j = i + 1; j < generators.Length; j++)
                {
                    var otherGenerator = generators[j];
                    if (generator == otherGenerator)
                        continue;

                    building = moveItems(none, new[] {generator, otherGenerator});
                    if (building.IsValid())
                        yield return building;
                }
            }
        }

        //public IEnumerable<Building> GetPossibleNextStates()
        //{
        //    var microchips = GetMicrochipsOnCurrentFloor();
        //    var generators = GetGeneratorsOnCurrentFloor();
        //    var none = new char[0];

        //    if (ElevatorLocation > 0) // can move down
        //    {
        //        foreach (var microchip in microchips)
        //        {
        //            var building = MoveDown(new[] {microchip}, none);
        //            if (building.IsValid())
        //            {
        //                yield return building;
        //            }

        //            foreach (var microchip2 in microchips)
        //            {
        //                if (microchip != microchip2)
        //                {
        //                    building = MoveDown(new[] {microchip, microchip2}, none);
        //                    if (building.IsValid())
        //                    {
        //                        yield return building;
        //                    }
        //                }
        //            }

        //            foreach (var generator in generators)
        //            {
        //                building = MoveDown(new[] { microchip }, new []{ generator });
        //                if (building.IsValid())
        //                {
        //                    yield return building;
        //                }   
        //            }
        //        }

        //        foreach (var generator in generators)
        //        {
        //            foreach (var generator2 in generators)
        //            {
        //                if (generator != generator2)
        //                {
        //                    var building = MoveDown(none, new[] {generator, generator2});
        //                    if (building.IsValid())
        //                    {
        //                        yield return building;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    if (ElevatorLocation < 3) // can move up
        //    {
        //        foreach (var microchip in microchips)
        //        {
        //            var building = MoveUp(new[] { microchip }, none);
        //            if (building.IsValid())
        //            {
        //                yield return building;
        //            }

        //            foreach (var microchip2 in microchips)
        //            {
        //                if (microchip != microchip2)
        //                {
        //                    building = MoveUp(new[] { microchip, microchip2 }, none);
        //                    if (building.IsValid())
        //                    {
        //                        yield return building;
        //                    }
        //                }
        //            }

        //            foreach (var generator in generators)
        //            {
        //                building = MoveUp(new[] { microchip }, new[] { generator });
        //                if (building.IsValid())
        //                {
        //                    yield return building;
        //                }    
        //            }
        //        }

        //        foreach (var generator in generators)
        //        {
        //            foreach (var generator2 in generators)
        //            {
        //                if (generator != generator2)
        //                {
        //                    var building = MoveUp(none, new[] { generator, generator2 });
        //                    if (building.IsValid())
        //                    {
        //                        yield return building;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        public char[] GetMicrochipsOnCurrentFloor()
        {
            var microchips = new List<char>();
            for (var i = 0; i < _symbols.Count; i++)
            {
                if (_microchipLocations[i] == ElevatorLocation)
                    microchips.Add(_symbols[i]);
            }
            return microchips.ToArray();
        }

        public char[] GetGeneratorsOnCurrentFloor()
        {
            var generators = new List<char>();
            for (var i = 0; i < _symbols.Count; i++)
            {
                if (_generatorLocations[i] == ElevatorLocation)
                    generators.Add(_symbols[i]);
            }
            return generators.ToArray();
        }



        private Building MoveUp(IEnumerable<char> microchips, IEnumerable<char> generators)
        {
            var newMicrochips = CloneMicrochipLocations();
            foreach (var m in microchips)
            {
                var i = _symbols.IndexOf(m);
                Debug.Assert(newMicrochips[i] == ElevatorLocation);
                newMicrochips[i]++;
            }

            var newGenerators = CloneGeneratorLocations();
            foreach (var g in generators)
            {
                var i = _symbols.IndexOf(g);
                Debug.Assert(newGenerators[i] == ElevatorLocation);
                newGenerators[i]++;
            }

            return new Building(_symbols, newMicrochips, newGenerators)
            {
                ElevatorLocation = ElevatorLocation + 1
            };
        }

        private Building MoveDown(IEnumerable<char> microchips, IEnumerable<char> generators)
        {
            var newMicrochips = CloneMicrochipLocations();
            foreach (var m in microchips)
            {
                var i = _symbols.IndexOf(m);
                Debug.Assert(newMicrochips[i] == ElevatorLocation);
                newMicrochips[i]--;
            }

            var newGenerators = CloneGeneratorLocations();
            foreach (var g in generators)
            {
                var i = _symbols.IndexOf(g);
                Debug.Assert(newGenerators[i] == ElevatorLocation);
                newGenerators[i]--;
            }

            return new Building(_symbols, newMicrochips, newGenerators)
            {
                ElevatorLocation = ElevatorLocation - 1
            };
        }

        private int[] CloneMicrochipLocations()
        {
            var newMicrochips = new int[_microchipLocations.Length];
            Array.Copy(_microchipLocations, newMicrochips, newMicrochips.Length);
            return newMicrochips;
        }

        private int[] CloneGeneratorLocations()
        {
            var newGenerators = new int[_generatorLocations.Length];
            Array.Copy(_generatorLocations, newGenerators, newGenerators.Length);
            return newGenerators;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var floorIndex = 3; floorIndex >= 0; floorIndex--)
            {
                sb.Append($"F{floorIndex + 1} ");
                sb.Append(ElevatorLocation == floorIndex ? "E  " : Missing);

                for (var elementIndex = 0; elementIndex < _symbols.Count; elementIndex++)
                {
                    sb.Append(_microchipLocations[elementIndex] == floorIndex ? AsMicrochip(_symbols[elementIndex]) : Missing);
                    sb.Append(_generatorLocations[elementIndex] == floorIndex ? AsGenerator(_symbols[elementIndex]) : Missing);
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

        public IEnumerable<Node> GetNextNodes()
        {
            return GetPossibleNextStates();
        }

        public int CompareTo(Node other)
        {
            return (int)(UniqueIdentifier - other.UniqueIdentifier);
        }

        public long UniqueIdentifier
        {
            get
            {
                var hash = 0;
                var generatorOffset = _microchipLocations.Length * 2;
                for (int i = 0, j = 0, k = generatorOffset; i < _microchipLocations.Length; i++, j+=2, k+=2)
                {
                    hash += _microchipLocations[i] << j;
                    hash += _generatorLocations[i] << k;
                }
                hash += ElevatorLocation << (4 * _microchipLocations.Length);
                return hash;
            }
        }
    }
}