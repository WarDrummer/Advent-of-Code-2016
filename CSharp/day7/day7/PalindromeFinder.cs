namespace day7
{
    public class PalindromeFinder
    {
        public static bool HasPalindrome(string s)
        {
            for (var i = 0; i <= s.Length - 4; i++)
            {
                if (s[i] != s[i + 1] && 
                    s[i] == s[i + 3] && 
                    s[i + 1] == s[i + 2])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
