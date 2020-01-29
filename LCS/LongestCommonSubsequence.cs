using System;

namespace LCS
{
    public class LongestCommonSubsequence
    {
        public enum Direction
        {
            UpLeft,
            Up,
            Left
        }

        public class LcsEntry
        {
            public Direction Direction { get; set;}
            public int Score { get; set;}
        }

        public string Compute()
        {
            return null;
        }

        private LcsEntry[,] Compute(string x, string y)
        {
            var table = new LcsEntry[x.Length, y.Length];
            for (int i = 0; i < y.Length; ++i)
            {
                for (int j = 0; j < x.Length; ++j)
                {
                    if (x[i] == y[j])
                    {
                        var score = GetScoreAt(table, i - 1, j - 1) + 1;
                        table[i,j] = new LcsEntry { Score = score, Direction = Direction.UpLeft };
                    }
                    else if (GetScoreAt(table, i - 1, j) >= GetScoreAt(table, i, j - 1))
                    {
                        var score = GetScoreAt(table, i - 1, j);
                        table[i,j] = new LcsEntry { Score = score, Direction = Direction.Up };
                    }
                    else
                    {
                        var score = GetScoreAt(table, i, j - 1);
                        table[i,j] = new LcsEntry { Score = score, Direction = Direction.Left };
                    }
                }
            }
            return table;
        }// Compute

        private int GetScoreAt(LcsEntry[,] table, int row, int column) => 
            (row < 0 || column < 0) ? 0 : table[row, column].Score;
    }
}
