using System;
using System.Collections.Generic;
using System.Text;
using Tools;

namespace day11
{
    using Node = INode<long>;
    public class Building : Node
    {
        private readonly IList<char> _symbols;
        private readonly int _symbolCount;
        private readonly int _generatorOffset;
        private readonly int _elevatorOffset;
        private readonly int[] _generatorLocations;
        private readonly int[] _microchipLocations;
        private readonly int _elevatorLocation;
        private const string Missing = ".  ";

        public static Building CreateGoalState(char[] symbols)
        {
            var goalStateBuilding = new Building(symbols, 3);
            foreach (var symbol in symbols)
            {
                goalStateBuilding.SetGeneratorLocation(3, symbol);
                goalStateBuilding.SetMicrochipLocation(3, symbol);
            }
            return goalStateBuilding;
        }

        public Building(IEnumerable<char> symbols, int elevatorLocation = 0)
        {
            _symbols = new List<char>(symbols);
            _symbolCount = _symbols.Count;
            _generatorOffset = _symbolCount << 1;
            _elevatorOffset = _symbolCount << 2;
            _generatorLocations = new int[_symbolCount];
            _microchipLocations = new int[_symbolCount];
            _elevatorLocation = elevatorLocation;
        }

        private Building(IEnumerable<char> symbols, int elevatorLocation, int[] microchipLocations, int[] generatorLocations)
        {
            _symbols = new List<char>(symbols);
            _symbolCount = _symbols.Count;
            _generatorOffset = _symbolCount << 1;
            _elevatorOffset = _symbolCount << 2;
            _microchipLocations = microchipLocations;
            _generatorLocations = generatorLocations;
            _elevatorLocation = elevatorLocation;
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
            for (var i = 0; i < _symbolCount; i++)
            {
                // if microchip isn't protected
                if (_microchipLocations[i] != _generatorLocations[i])
                {
                    for (var j = 0; j < _symbolCount; j++)
                    {
                        if (_generatorLocations[j] == _microchipLocations[i])
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

            if (_elevatorLocation > 0)
            {
                foreach (var building in CreateNewState(microchips, generators, MoveDown))
                    yield return building;
            }

            if (_elevatorLocation < 3)
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

        public char[] GetMicrochipsOnCurrentFloor()
        {
            var microchips = new List<char>();
            for (var i = 0; i < _symbolCount; i++)
            {
                if (_microchipLocations[i] == _elevatorLocation)
                    microchips.Add(_symbols[i]);
            }
            return microchips.ToArray();
        }

        public char[] GetGeneratorsOnCurrentFloor()
        {
            var generators = new List<char>();
            for (var i = 0; i < _symbolCount; i++)
            {
                if (_generatorLocations[i] == _elevatorLocation)
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
                newMicrochips[i]++;
            }

            var newGenerators = CloneGeneratorLocations();
            foreach (var g in generators)
            {
                var i = _symbols.IndexOf(g);
                newGenerators[i]++;
            }

            return new Building(_symbols, _elevatorLocation + 1, newMicrochips, newGenerators);
        }

        private Building MoveDown(IEnumerable<char> microchips, IEnumerable<char> generators)
        {
            var newMicrochips = CloneMicrochipLocations();
            foreach (var m in microchips)
            {
                var i = _symbols.IndexOf(m);
                newMicrochips[i]--;
            }

            var newGenerators = CloneGeneratorLocations();
            foreach (var g in generators)
            {
                var i = _symbols.IndexOf(g);
                newGenerators[i]--;
            }

            return new Building(_symbols, _elevatorLocation - 1, newMicrochips, newGenerators);
        }

        private int[] CloneMicrochipLocations()
        {
            var newMicrochips = new int[_symbolCount];
            Array.Copy(_microchipLocations, newMicrochips, _symbolCount);
            return newMicrochips;
        }

        private int[] CloneGeneratorLocations()
        {
            var newGenerators = new int[_symbolCount];
            Array.Copy(_generatorLocations, newGenerators, _symbolCount);
            return newGenerators;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var floorIndex = 3; floorIndex >= 0; floorIndex--)
            {
                sb.Append($"F{floorIndex + 1} ");
                sb.Append(_elevatorLocation == floorIndex ? "E  " : Missing);

                for (var elementIndex = 0; elementIndex < _symbolCount; elementIndex++)
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

                for (int i = 0, j = 0, k = _generatorOffset; i < _symbolCount; i++, j+=2, k+=2)
                {
                    hash |= _microchipLocations[i] << j;
                    hash |= _generatorLocations[i] << k;
                }

                hash |= _elevatorLocation << _elevatorOffset;
                return hash;
            }
        }
    }
}