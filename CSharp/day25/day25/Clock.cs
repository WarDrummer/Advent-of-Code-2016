using System;

namespace day25
{
    public class Clock
    {
        private long _previous = -1;
        public int NumberValidValues { get; private set; } = 0;

        public void Transmit(long value)
        {
            if(value != 0 && value != 1)
                throw new Exception("Invalid clock signal");

            if (_previous == value)
                throw new Exception("Clock signal must alternate");

            _previous = value;
            NumberValidValues++;
        }

        public void Reset()
        {
            _previous = -1;
            NumberValidValues = 0;
        }
    }
}