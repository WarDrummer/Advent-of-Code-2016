using System.Collections.Generic;

namespace day11
{
    public class BuildingStateGenerator
    {
        private Building _building;

        public BuildingStateGenerator(Building building)
        {
            _building = building;
        }

        public IEnumerable<Building> GetPossibleNextStates()
        {
            var microchips = GetMicrochipsOnCurrentFloor();
            var generators = GetGeneratorsOnCurrentFloor();
            var none = new char[0];

            if (_building._elevatorLocation > 0) // can move down
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

            if (_building._elevatorLocation < 3) // can move up
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
            for (var i = 0; i < _building._symbols.Count; i++)
            {
                if (_building._floors[_building._elevatorLocation][i])
                {
                    microchips.Add(_building._symbols[i]);
                }
            }
            return microchips.ToArray();
        }

        private char[] GetGeneratorsOnCurrentFloor()
        {
            var generators = new List<char>();
            for (var i = 0; i < _building._symbols.Count; i++)
            {
                if (_building._floors[_building._elevatorLocation][i + _building._symbols.Count])
                {
                    generators.Add(_building._symbols[i]);
                }
            }
            return generators.ToArray();
        }

        private Building MoveUp(char[] microchips, char[] generators)
        {
            var floors = CloneFloors();
            foreach (var microchip in microchips)
            {
                var index = _building._symbols.IndexOf(microchip);
                floors[_building._elevatorLocation][index] = false;
                floors[_building._elevatorLocation + 1][index] = true;
            }

            foreach (var generator in generators)
            {
                var index = _building._symbols.IndexOf(generator) + _building._symbols.Count;
                floors[_building._elevatorLocation][index] = false;
                floors[_building._elevatorLocation + 1][index] = true;
            }

            return new Building(_building._symbols, floors)
            {
                _elevatorLocation = _building._elevatorLocation + 1
            };
        }

        private Building MoveDown(char[] microchips, char[] generators)
        {
            var floors = CloneFloors();
            foreach (var microchip in microchips)
            {
                var index = _building._symbols.IndexOf(microchip);
                floors[_building._elevatorLocation][index] = false;
                floors[_building._elevatorLocation - 1][index] = true;
            }

            foreach (var generator in generators)
            {
                var index = _building._symbols.IndexOf(generator) + _building._symbols.Count;
                floors[_building._elevatorLocation][index] = false;
                floors[_building._elevatorLocation - 1][index] = true;
            }

            return new Building(_building._symbols, floors)
            {
                _elevatorLocation = _building._elevatorLocation - 1
            };
        }

        private bool[][] CloneFloors()
        {
            return _building._floors.Select(a => a.ToArray()).ToArray();
        }
    }
}