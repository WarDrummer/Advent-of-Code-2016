namespace day11
{
    public class FloorValidator
    {
        private readonly bool[] _floor;
        private readonly int _numberOfElements;

        public FloorValidator(bool[] floor)
        {
            _floor = floor;
            _numberOfElements = _floor.Length / 2;
        }

        public bool IsFloorValid()
        {
            for (var elementIndex = 0; elementIndex < _numberOfElements; elementIndex++)
            {
                var microchipExists = _floor[elementIndex];
                if (microchipExists && !GetGenerator(elementIndex) && AreGeneratorsPresent())
                    return false;
            }
            return true;
        }

        private bool GetGenerator(int elementIndex)
        {
            return _floor[elementIndex + _numberOfElements];
        }

        private bool AreGeneratorsPresent()
        {
            for (var generatorIndex = _numberOfElements; generatorIndex < _numberOfElements * 2; generatorIndex++)
            {
                if (_floor[generatorIndex])
                    return true;
            }
            return false;
        }
    }
}