using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lines
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
                    grid[row, col] = (byte)((number >> col) & 1);
                }
            }
            byte bestCount = 0;
            byte bestLineLength = 0;
            for (byte row = 0; row < 8; row++)
            {
                byte length = 0;
                for (byte col = 0; col < 8; col++)
                {
                    if (grid[row, col] == 1)
                    {
                        length++;
                        if (length > bestLineLength)
                        {
                            bestLineLength = length;
                            bestCount = 0;
                        }
                        if (length == bestLineLength)
                        {
                            bestCount++;
                        }
                    }
                    else
                    {
                        length = 0;
                    }
                }
            }
            for (byte col = 0; col < 8; col++)
            {
                byte length = 0;
                for (byte row = 0; row < 8; row++)
                {
                    if (grid[row, col] == 1)
                    {
                        length++;
                        if (length > bestLineLength)
                        {
                            bestLineLength = length;
                            bestCount = 0;
                        }
                        if (length == bestLineLength)
                        {
                            bestCount++;
                        }
                    }
                    else
                    {
                        length = 0;
                    }
                }
            }
            if (bestLineLength == 1)
            {
                bestCount /= 2;
            }
            Console.WriteLine(bestLineLength + "\n" + bestCount);
        }
    }
}
