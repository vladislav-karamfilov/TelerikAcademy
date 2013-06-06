using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] grid = new char[8, 8];
            for (int row = 0; row < 8; row++)
            {
                int number = int.Parse(Console.ReadLine());
                for (int col = 0; col < 8; col++)
                {
                    if (((number >> col) & 1) == 1)
                    {
                        grid[row, col] = 'T';
                    }
                    else
                    {
                        grid[row, col] = '0';
                    }
                }
            }
            for (int row = 0; row < 8; row++)
            {
                int number = int.Parse(Console.ReadLine());
                for (int col = 0; col < 8; col++)
                {
                    if (((number >> col) & 1) == 1)
                    {
                        if (grid[row, col] == 'T')
                        {
                            grid[row, col] = '0';
                            continue;
                        }
                        grid[row, col] = 'B';
                    }
                }
            }
            for (int row = 0; row < 8; row++)
            {
                for (int col = 7; col >= 0; col--)
                {
                    Console.Write(grid[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
