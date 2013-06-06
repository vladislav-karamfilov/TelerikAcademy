using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSums
{
    class Program
    {
        static void Main(string[] args)
        {
            long s = long.Parse(Console.ReadLine());
            byte n = byte.Parse(Console.ReadLine());
            long[] numbers = new long[n];
            for (int index = 0; index < n; index++)
            {
                numbers[index] = long.Parse(Console.ReadLine());
            }
            int allSubsets = (int)Math.Pow(2, n);
            int count = 0;
            for (int subset = 1; subset < allSubsets; subset++)
            {
                long currentSum = 0;
                for (int i = 0; i < n; i++)
                {
                    int mask = 1 << i;
                    int iElement = subset & mask;
                    if ((iElement >> i) == 1)
                    {
                        currentSum += numbers[i];
                    }
                }
                if (currentSum == s)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
