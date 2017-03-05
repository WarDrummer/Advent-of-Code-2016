using System.Runtime.CompilerServices;

namespace day9
{
    public class Decompressor
    {
        public int GetDecompressedLength(string s)
        {
            var count = 0;
            var inParens = false;
            var startIndex = -1;
            for (var index = 0; index < s.Length; index++)
            {
                var c = s[index];
                if (inParens)
                {
                    if (!IsEndMarker(c))
                        continue;

                    inParens = false;
                    var substring = s.Substring(startIndex, index - startIndex);
                    var parts = substring.Split('x');
                    var a = int.Parse(parts[0]);
                    count += (a * int.Parse(parts[1]));
                    index += a;
                }
                else if (IsStartMarker(c))
                {
                    inParens = true;
                    startIndex = index + 1;
                }
                else
                {
                    count++;
                }
            }

            return count;
        }

        public ulong GetModifiedDecompressedLength(string s)
        {
            ulong count = 0;
            var inParens = false;
            var startIndex = -1;
            for (var index = 0; index < s.Length; index++)
            {
                var c = s[index];
                if (inParens)
                {
                    if (!IsEndMarker(c))
                        continue;

                    inParens = false;
                    var modifierSubstring = s.Substring(startIndex, index - startIndex);
                    var parts = modifierSubstring.Split('x');
                    var howManyCharacters = int.Parse(parts[0]);
                    var numberOfTimesToRepeat = ulong.Parse(parts[1]);

                    var substringToRepeat = s.Substring(index + 1, howManyCharacters);
                    var decompressedLengthOfSubstring = GetModifiedDecompressedLength(substringToRepeat);
                    count += decompressedLengthOfSubstring * numberOfTimesToRepeat;
                    index += howManyCharacters;
                }
                else if (IsStartMarker(c))
                {
                    inParens = true;
                    startIndex = index + 1;
                }
                else
                {
                    count++;
                }
            }

            return count;
        }

        private static bool IsStartMarker(char c)
        {
            return c == '(';
        }

        private static bool IsEndMarker(char c)
        {
            return c == ')';
        }
    }
}