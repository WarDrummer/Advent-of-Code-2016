namespace day6
{
    public class FrequencyAnalyzer
    {
        private readonly char[][] frequency;
        public FrequencyAnalyzer(int length)
        {
            frequency = new char[length][];
            for (var i = 0; i < length; i++)
            {
                frequency[i] = new char[256];
            }
        }

        public void Add(string s)
        {
            for (var i = 0; i < s.Length; i++)
            {
                frequency[i][s[i]]++;
            }
        }

        public string GetMessage()
        {
            var message = new char[frequency.Length];
            for (var i = 0; i < frequency.Length; i++)
            {
                var max = 0;
                for (var j = 0; j < 256; j++)
                {
                    if (frequency[i][j] > max)
                    {
                        max = frequency[i][j];
                        message[i] = (char)j;
                    }
                }
            }

            return new string(message);
        }

        public string GetModifiedMessage()
        {
            var message = new char[frequency.Length];
            for (var i = 0; i < frequency.Length; i++)
            {
                var min = int.MaxValue;
                for (var j = 0; j < 256; j++)
                {
                    if (frequency[i][j] != 0 && frequency[i][j] < min)
                    {
                        min = frequency[i][j];
                        message[i] = (char)j;
                    }
                }
            }

            return new string(message);
        }
    }
}