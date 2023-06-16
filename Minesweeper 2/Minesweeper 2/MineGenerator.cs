
// MineGenerator.cs
using System;

namespace Minesweeper_2
{
    public static class MineGenerator
    {
        public static int[] GenerateMines()
        {
            int[] mines = new int[10];
            Random random = new Random();

            for (int i = 0; i < 10; ++i)
            {
                mines[i] = random.Next(1, 82);

                for (int j = 0; j < i; ++j)
                {
                    if (mines[i] == mines[j])
                    {
                        mines[i] = random.Next(1, 82);
                        j = 0;
                    }
                }
            }

            Array.Sort(mines);
            return mines;
        }
    }
}

