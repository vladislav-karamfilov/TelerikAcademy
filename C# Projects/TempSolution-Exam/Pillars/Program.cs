using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillars
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[,] grid = new byte[8, 8];
            for (byte row = 0; row < 8; row++)
            {
                byte number = byte.Parse(Console.ReadLine());
                for (byte col = 0; col < 8; col++)
                {
                    grid[row, col] = (byte)(number >> col & 1);
                }
            }
            for (int pillar = 7; pillar >= 0; pillar--)
            {
                byte rightCount = 0;
                byte leftCount = 0;
                for (byte row = 0; row < 8; row++)
                {
                    for (byte col = 0; col < 8; col++)
                    {
                        if (col < pillar)
                        {
                            leftCount += grid[row, col];
                        }
                        else if (col > pillar)
                        {
                            rightCount += grid[row, col];
                        }
                    }
                }
                if (rightCount == leftCount)
                {
                    Console.WriteLine(pillar);
                    Console.WriteLine(leftCount);
                    return;
                }
            }
            Console.WriteLine("No");
        }
    }
}
