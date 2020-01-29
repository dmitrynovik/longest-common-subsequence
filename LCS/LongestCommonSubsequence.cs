using System.Collections.Generic;
using System.Linq;

namespace LCS
{
    public static class LongestCommonSubsequence
    {
        public enum Direction { UpLeft, Up, Left }

        public class LcsEntry
        {
            public LcsEntry(Direction direction, int score)
            {
                Direction = direction;
                Score = score;
            }

            public Direction Direction { get; }
            public int Score { get; }
        }

        public static string Compute(string x, string y)
        {
            if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y))
                return "";

            var table = ComputeImpl(x, y);

            return new string(PrintLCSInReverse(table, x)
                .Reverse()
                .ToArray());
        }

        private static IEnumerable<char> PrintLCSInReverse(LcsEntry[,] table, string x)
        {
            var i = table.GetLength(0) - 1;
            var j = table.GetLength(1) - 1;

            while (i >= 0 && j >= 0)
            {
                var e = table[i, j];
                if (e.Direction == Direction.UpLeft)
                {
                    yield return x[i];
                    i--;
                    j--;
                }
                else if (e.Direction == Direction.Left)
                    j--;
                else
                    i--;
            }
        }

        private static LcsEntry[,] ComputeImpl(string x, string y)
        {
            var table = new LcsEntry[x.Length, y.Length];

            for (int i = 0; i < x.Length; ++i)
            {
                for (int j = 0; j < y.Length; ++j)
                {
                    if (x[i] == y[j])
                    {
                        var score = GetScoreAt(table, i - 1, j - 1) + 1;
                        table[i,j] = new LcsEntry(Direction.UpLeft, score);
                    }
                    else if (GetScoreAt(table, i - 1, j) >= GetScoreAt(table, i, j - 1))
                    {
                        var score = GetScoreAt(table, i - 1, j);
                        table[i,j] = new LcsEntry(Direction.Up, score);
                    }
                    else
                    {
                        var score = GetScoreAt(table, i, j - 1);
                        table[i,j] = new LcsEntry(Direction.Left, score);
                    }
                }
            }
            return table;
        }// Compute

        private static int GetScoreAt(LcsEntry[,] table, int row, int column) => 
            (row < 0 || column < 0) ? 0 : table[row, column].Score;
    }
}
