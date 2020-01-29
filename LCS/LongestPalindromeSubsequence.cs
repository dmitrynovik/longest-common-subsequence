using System.Linq;

namespace LCS 
{
    public static class LongestPalindromeSusequence
    {
        public static string Compute(string x) => LongestCommonSubsequence.Compute(x, Reverse(x));

        private static string Reverse(string x) => x == null ? null : new string(x.Reverse().ToArray());

    }
}