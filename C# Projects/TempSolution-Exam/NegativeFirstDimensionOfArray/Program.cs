using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegativeFirstDimensionOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int neg = -7;
            int pos = 15;
            int sum = 7;
            long n = Math.Abs(neg) + Math.Abs(sum) + 1;
            long[,] array = new long[2, n];
            for (int i = 0; i < n; i++)
            {
                array[0, i] = neg + i;
            }
            for (int row = 0; row < 2; row++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array[row, j] + "   ");
                }
                Console.WriteLine();
            }
        }
    }
}
